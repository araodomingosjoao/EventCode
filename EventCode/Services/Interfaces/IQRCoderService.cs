using QRCoder;
using System;
using System.Drawing;
using System.IO;

namespace EventCode.Services.Interfaces
{
    public interface IQRCoderService
    {
        public Bitmap Generator(string url, Guid id);
        public Stream ToStream(Bitmap qrcode);
    }
}
