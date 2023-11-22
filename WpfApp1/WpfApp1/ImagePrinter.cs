using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    internal class ImagePrinter
    {
        private System.Windows.Controls.Image _imageControl;

        public ImagePrinter(System.Windows.Controls.Image imageControl)
        {
            _imageControl = imageControl;
        }

        public void Print()
        {
            // Define parameters used to create the BitmapSource.
            PixelFormat pf = PixelFormats.BlackWhite;
            int width = 12800;
            int height = 12800;
            int rawStride = (width * pf.BitsPerPixel + 7) / 8;
            byte[] rawImage = new byte[rawStride * height];

            // Initialize the image with data.
            Random value = new Random();
            value.NextBytes(rawImage);

            // Create a BitmapSource.
            BitmapSource bitmap = BitmapSource.Create(width, height,
                96, 96, pf, null,
                rawImage, rawStride);

            // Set image source.
            _imageControl.Source = bitmap;
        }

        private static System.Drawing.Point GetRandomPoint()
        {
            Random r1 = new System.Random();
            return new(r1.Next(0, 639) * 20, r1.Next(0, 639) * 20);
        }
    }
}
