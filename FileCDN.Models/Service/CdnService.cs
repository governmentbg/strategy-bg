using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using FileCDN.Models.Data;
using System.Linq;
using ImageProcessor;
using Elastic.Models.Contracts;
using Elastic.Models;
using Elastic.Models.Data;

namespace FileCDN.Models.Service
{
    public class CdnService<T> : ICdnService<T> where T : DbContext
    {
        private readonly T db;
        private DbSet<FileCdn> FILES;
        private DbSet<FileCdnContent> CONTENT;
        private readonly IImageService imgService;
        private readonly IDataIndexerService dataIndexerService;

        public CdnService(T _db, IImageService _imgService, IDataIndexerService _dataIndexerService)
        {
            db = _db;
            FILES = db.Set<FileCdn>();
            CONTENT = db.Set<FileCdnContent>();

            imgService = _imgService;
            dataIndexerService = _dataIndexerService;
        }

        public bool Disable(FileSelect model)
        {
            var cdnFile = FILES.Find(model.FileId);
            if (cdnFile != null)
            {
                cdnFile.IsActive = false;
                FILES.Update(cdnFile);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public FileInfo Download(FileSelect model)
        {
            FileInfo result = new FileInfo();
            try
            {
                Func<FileCdn, bool> fileSelect = x => false;
                if (!string.IsNullOrEmpty(model.FileId))
                {
                    fileSelect = x => x.Id == model.FileId;
                }
                else
                {
                    fileSelect = x => x.SourceType == model.SourceType && x.SourceId == model.SourceID;
                }
                var cdnFile = FILES.Where(fileSelect).FirstOrDefault();
                if (cdnFile != null)
                {
                    result.Id = cdnFile.Id;
                    result.FileName = cdnFile.FileName;
                    result.FileTitle = cdnFile.FileTitle;
                    result.ContentType = cdnFile.ContentType;
                    var contents = CONTENT.Where(x => x.CdnFileId == cdnFile.Id).OrderBy(x => x.Id).ToList();

                    List<byte> content = new List<byte>();

                    foreach (var contentItem in contents)
                    {
                        content.AddRange(contentItem.Content);
                    }

                    result.FileContent = content.ToArray();
                }
            }
            catch (Exception ex)
            {
                result.FileDescription = ex.Message;
            }

            return result;
        }


        public IEnumerable<FileInfo> Select(FileSelect model)
        {
            Func<FileCdn, bool> where = x => true;

            if (!string.IsNullOrEmpty(model.SearchText))
            {
                model.SearchText = model.SearchText.ToLower();
            }

            if (!string.IsNullOrEmpty(model.FileId))
            {
                where = x => x.Id == model.FileId;
            }
            else
            {
                where = x => x.SourceType == model.SourceType && x.SourceId == model.SourceID;
            }

            return FILES
                .Where(where)
                .Select(x => new FileInfo
                {
                    Id = x.Id,
                    FileTitle = x.FileTitle ?? "",
                    FileDescription = x.FileDescription,
                    FileName = x.FileName,
                    DateUploaded = x.DateUploaded,
                    IsActive = x.IsActive,
                    UserUploaded = x.UserUploaded,
                    SourceID = x.SourceId,
                    SourceType = x.SourceType
                })
                .Where(x => x.FileTitle.ToLower().Contains(model.SearchText ?? x.FileTitle.ToLower()));
        }

        public FileUploadResult Upload(FileRequest model)
        {
            var result = SaveFile(model);

            if (model.ThumbSourceType > 0)
            {
                try
                {
                    var tmb = new FileRequest()
                    {
                        SourceType = model.ThumbSourceType,
                        SourceID = result.FileId.ToString(),
                        FileName = model.FileName,
                        UserUploaded = model.UserUploaded,
                        ContentType = model.ContentType,                        
                        FileContent = imgService.Resize(model.FileContent, model.ThumbMaxSize, model.ContentType)
                    };


                    SaveFile(tmb);
                }
                catch (Exception ex) { }
            }

            return result;
        }

        private FileUploadResult SaveFile(FileRequest model)
        {
            FileUploadResult result = new FileUploadResult()
            {
                SavedOK = false
            };
            try
            {
                FileCdn cdnFile = new FileCdn()
                {
                    SourceType = model.SourceType,
                    SourceId = model.SourceID,
                    FileName = model.FileName,
                    FileSize = model.FileContent.Length,
                    FileTitle = model.FileTitle,
                    FileDescription = model.FileDescription,
                    DateUploaded = DateTime.Now,
                    UserUploaded = model.UserUploaded,
                    ContentType = model.ContentType,
                    DateExparing = model.DateExparing,
                    IsReportVisible = model.IsReportVisible,
                    IsActive = true
                };

                //Те това е къде 1Мб
                int maxFilePartLenght = 1048576;
                using (System.IO.Stream fileContent = new System.IO.MemoryStream(model.FileContent))
                {

                    int totalChunks = Convert.ToInt32(Math.Ceiling((decimal)cdnFile.FileSize / maxFilePartLenght));
                    for (int i = 0; i <= totalChunks - 1; i++)
                    {
                        int startIndex = (i * maxFilePartLenght);
                        int endIndex = 0;
                        if ((startIndex + maxFilePartLenght > cdnFile.FileSize))
                        {
                            endIndex = cdnFile.FileSize;
                        }
                        else
                        {
                            endIndex = startIndex + maxFilePartLenght;
                        }
                        int length = endIndex - startIndex;
                        byte[] bytes = new byte[length];
                        fileContent.Read(bytes, 0, bytes.Length);

                        cdnFile.FileContents.Add(new FileCdnContent()
                        {
                            Content = bytes
                        });
                    }

                    FILES.Add(cdnFile);
                    db.SaveChanges();
                    result.FileId = cdnFile.Id;
                    result.SavedOK = !string.IsNullOrEmpty(result.FileId);

                    //***Indexing in Elastic******************************************************************
                    try
                    {
                        elasticContent _document = new elasticContent(cdnFile.Id,
                                                                      Convert.ToBase64String(model.FileContent),
                                                                      dataIndexerService.PathCreator(SystemPaths.CDN, cdnFile.Id));
                        dataIndexerService.indexDocument(_document);
                    }
                    catch (Exception es_ex)
                    { }
                    //***************************************************************************************

                }

                result.SavedOK = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //private byte[] ResizeImage(byte[] original, int maxSize, string contentType)
        //{

        //    //var codek = SKCodec.Create(SKData.Create())


        //    var bitmap = SKBitmap.Decode(original);

        //    var resizeFactor = (float)maxSize / Math.Max(bitmap.Width, bitmap.Height);
        //    if (resizeFactor > 1f)
        //    {
        //        return original;
        //    }
        //    var toBitmap = new SKBitmap((int)Math.Round(bitmap.Width * resizeFactor), (int)Math.Round(bitmap.Height * resizeFactor), bitmap.ColorType, bitmap.AlphaType);

        //    var canvas = new SKCanvas(toBitmap);
        //    // Draw a bitmap rescaled
        //    canvas.SetMatrix(SKMatrix.MakeScale(resizeFactor, resizeFactor));


        //    //var codec = SKCodec.Create(SKData.Create(new MemoryStream(original)));

        //    // rotate according to origin
        //    // NOTE: I DID NOT TEST THIS BLOCK AT ALL
        //    //switch (codec.Origin)
        //    //{
        //    //    case SKCodecOrigin.TopRight:
        //    //        // flip along the x-axis
        //    //        canvas.Scale(-1, 1);
        //    //        break;
        //    //    case SKCodecOrigin.BottomRight:
        //    //        // rotate right around
        //    //        canvas.RotateDegrees(180);
        //    //        break;
        //    //    case SKCodecOrigin.BottomLeft:
        //    //        break;
        //    //    case SKCodecOrigin.LeftTop:
        //    //        break;
        //    //    case SKCodecOrigin.RightTop:
        //    //        break;
        //    //    case SKCodecOrigin.RightBottom:
        //    //        break;
        //    //    case SKCodecOrigin.LeftBottom:
        //    //        break;
        //    //    case SKCodecOrigin.TopLeft:
        //    //    default:
        //    //        break;
        //    //}



        //    canvas.DrawBitmap(bitmap, 0, 0);
        //    canvas.ResetMatrix();

        //    canvas.Flush();

        //    var image = SKImage.FromBitmap(toBitmap);

        //    SKEncodedImageFormat imgType = SKEncodedImageFormat.Jpeg;
        //    if (contentType.ToLower().Contains("png"))
        //    {
        //        imgType = SKEncodedImageFormat.Png;
        //    }
        //    if (contentType.ToLower().Contains("bmp"))
        //    {
        //        imgType = SKEncodedImageFormat.Bmp;
        //    }
        //    if (contentType.ToLower().Contains("gif"))
        //    {
        //        imgType = SKEncodedImageFormat.Gif;
        //    }
        //    var data = image.Encode(imgType, 98);


        //    var stream = new MemoryStream();

        //    data.SaveTo(stream);
        //    stream.Position = 0;

        //    BinaryReader br = new BinaryReader(stream);
        //    return br.ReadBytes((int)stream.Length);

        //}



    }


}
