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
            switch (System.IO.Path.GetExtension(fileName).ToLower())
            {
                case ".pdf":
                    return @"/dist/assets/icon_pdf.png";
                case ".doc":
                case ".docx":
                    return @"/dist/assets/icon_word.png";
                default:
                    return string.Empty;
            }
        }
    }
}
