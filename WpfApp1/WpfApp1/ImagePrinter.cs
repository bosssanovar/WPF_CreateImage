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

        public void Print(bool[,] values)
        {
            var gridImage = new GridImage(values);

            // Define parameters used to create the BitmapSource.
            PixelFormat pf = PixelFormats.Gray8;
            int width = gridImage.Width;
            int height = gridImage.Height;
            //int rawStride = (width * pf.BitsPerPixel + 7) / 8;
            int rawStride = width;
            //byte[] rawImage = new byte[rawStride * height];
            byte[] rawImage = gridImage.GetImageArray();

            // Create a BitmapSource.
            BitmapSource bitmap = BitmapSource.Create(width, height,
                96, 96, pf, null,
                rawImage, rawStride);

            // Set image source.
            _imageControl.Source = bitmap;
        }
    }
}
