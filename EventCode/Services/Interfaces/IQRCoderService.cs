using QRCoder;
using System;
using System.Drawing;

namespace EventCode.Services.Interfaces
{
    public interface IQRCoderService
    {
        public Bitmap Generator(string url, Guid id);
    }
}
