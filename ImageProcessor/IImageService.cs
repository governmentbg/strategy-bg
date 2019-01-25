using System;

namespace ImageProcessor
{
    public interface IImageService
    {
        byte[] Resize(byte[] imgData, int maxSize, string contentType);
    }
}
