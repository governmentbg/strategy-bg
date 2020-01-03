using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class AssetsExtensions
    {
        public static string GetFileExtensionImage(this string fileName)
        {
      //switch (System.IO.Path.GetExtension(fileName).ToLower())
      //{
      //  case ".pdf":
      //    return @"/dist/assets/icon_pdf.png";
      //  case ".doc":
      //  case ".docx":
      //    return @"/dist/assets/icon_word.png";
      //  case ".xsl":
      //  case ".xslx":
      //    return @"/dist/assets/icon_excel.png";
      //  case ".arj":
      //  case ".zip":
      //  case ".rar":
      //    return @"/dist/assets/icon_rar.png";
      //  default:
      //    return @"/dist/assets/icon_file.png";
      //}
      switch (System.IO.Path.GetExtension(fileName).ToLower())
      {
        case ".pdf":
          return @"/dist/assets/pdf_o.jpg";
        case ".doc":
        case ".docx":
          return @"/dist/assets/doc_o.gif";
        case ".xsl":
        case ".xslx":
          return @"/dist/assets/xsl_o.gif";
        case ".arj":
        case ".zip":
        case ".rar":
          return @"/dist/assets/icon_rar_o.png";
        default:
          return @"/dist/assets/icon_file_o.png";
      }
    }
    }
}
