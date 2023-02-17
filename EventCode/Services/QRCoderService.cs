using EventCode.Services.Interfaces;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace EventCode.Services
{
    public class QRCoderService : IQRCoderService
    {
        public Bitmap Generator(string url, Guid id)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url+id.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // Renderize o código QR em um objeto Bitmap
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }

        public Stream ToStream(Bitmap qrcode)
        {
            MemoryStream ms = new MemoryStream();
            qrcode.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            return ms;
        }
    }
}
