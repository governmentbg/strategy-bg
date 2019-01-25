using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageProcessor
{
    public class ImageService : IImageService
    {
        public byte[] Resize(byte[] imgData, int maxSize, string contentType)
        {
            //return ResizeImageNew(imgData, maxSize, contentType);
            // create the codec
            SKCodec codec = SKCodec.Create(SKData.Create(new MemoryStream(imgData)));
            SKImageInfo info = codec.Info;

            float resizeFactor = (float)maxSize / Math.Max(info.Width, info.Height);
            if (resizeFactor > 1f)
            {
                return imgData;
            }

            // get the scale that is nearest to what we want (eg: jpg returned 512)
            SKSizeI supportedScale = codec.GetScaledDimensions(resizeFactor);

            // decode the bitmap at the nearest size
            SKImageInfo nearest = new SKImageInfo(supportedScale.Width, supportedScale.Height);
            SKBitmap bmp = SKBitmap.Decode(codec, nearest);

            // now scale that to the size that we want
            SKImageInfo desiredSize = new SKImageInfo((int)(info.Width * resizeFactor), (int)(info.Height * resizeFactor));

            bmp = bmp.Resize(desiredSize, SKBitmapResizeMethod.Lanczos3);

            if (codec.Origin == SKCodecOrigin.BottomRight || codec.Origin == SKCodecOrigin.BottomLeft)
            {
                bmp = bmp.Flip();
            }

            if (bmp.ColorType != SKImageInfo.PlatformColorType)
            {
                bmp.CopyTo(bmp, SKImageInfo.PlatformColorType);
            }
            SKImage image = SKImage.FromBitmap(bmp);


            SKEncodedImageFormat imgType = SKEncodedImageFormat.Jpeg;
            if (contentType.ToLower().Contains("png"))
            {
                imgType = SKEncodedImageFormat.Png;
            }
            if (contentType.ToLower().Contains("bmp"))
            {
                imgType = SKEncodedImageFormat.Bmp;
            }
            if (contentType.ToLower().Contains("gif"))
            {
                imgType = SKEncodedImageFormat.Gif;
            }
            var data = image.Encode(imgType, 100);


            var stream = new MemoryStream();

            data.SaveTo(stream);
            stream.Position = 0;

            BinaryReader br = new BinaryReader(stream);
            return br.ReadBytes((int)stream.Length);

        }

        private byte[] ResizeImageNew(byte[] original, int maxSize, string contentType)
        {

            int desiredWidth = maxSize;

            // create the codec
            SKCodec codec = SKCodec.Create(SKData.Create(new MemoryStream(original)));
            SKImageInfo info = codec.Info;

            // get the scale that is nearest to what we want (eg: jpg returned 512)
            SKSizeI supportedScale = codec.GetScaledDimensions((float)desiredWidth / info.Width);

            // decode the bitmap at the nearest size
            SKImageInfo nearest = new SKImageInfo(supportedScale.Width, supportedScale.Height);
            SKBitmap bmp = SKBitmap.Decode(codec, nearest);

            // now scale that to the size that we want
            float realScale = (float)info.Height / info.Width;
            SKImageInfo desired = new SKImageInfo(desiredWidth, (int)(realScale * desiredWidth));
            bmp = bmp.Resize(desired, SKBitmapResizeMethod.Lanczos3);

            var image = SKImage.FromBitmap(bmp);

            SKEncodedImageFormat imgType = SKEncodedImageFormat.Jpeg;
            if (contentType.ToLower().Contains("png"))
            {
                imgType = SKEncodedImageFormat.Png;
            }
            if (contentType.ToLower().Contains("bmp"))
            {
                imgType = SKEncodedImageFormat.Bmp;
            }
            if (contentType.ToLower().Contains("gif"))
            {
                imgType = SKEncodedImageFormat.Gif;
            }
            var data = image.Encode(imgType, 100);


            var stream = new MemoryStream();

            data.SaveTo(stream);
            stream.Position = 0;

            BinaryReader br = new BinaryReader(stream);
            return br.ReadBytes((int)stream.Length);

        }
    }

    public static class SkiaExt
    {
        public static SKBitmap Flip(this SKBitmap bmp)
        {
            var rotated = new SKBitmap(bmp.Width, bmp.Height);

            using (var surface = new SKCanvas(rotated))
            {
                surface.RotateDegrees(180, rotated.Width / 2, rotated.Height / 2);
                surface.DrawBitmap(bmp, 0, 0);
            }

            return rotated;
        }
    }
}
