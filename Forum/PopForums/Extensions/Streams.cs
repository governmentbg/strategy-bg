﻿using System.IO;

namespace PopForums.Extensions
{
    public static class Streams
    {
	    public static byte[] ToBytes(this Stream stream)
	    {
			var length = (int)stream.Length;
			var bytes = new byte[length];
			stream.Read(bytes, 0, length);
			return bytes;
		}
    }
}
