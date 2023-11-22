using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    internal class ImagePrinter
    {
        private Bitmap _bitmap = new Bitmap(12800, 12800);

        private System.Windows.Controls.Image _imageControl;

        public ImagePrinter(System.Windows.Controls.Image imageControl)
        {
            _imageControl = imageControl;
        }

        public void Print()
        {
            Bitmap image = GetBitmap();
            IntPtr hbitmap = image.GetHbitmap();

            _imageControl.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            
            DeleteObject(hbitmap);
        }

        private Bitmap GetBitmap()
        {
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(_bitmap);

            //描画する
            var pen = new Pen(Color.Black, 10);
            for (int i = 0; i < 10000; i++)
            {
                // 描画位置
                var point = GetRandomPoint();
                //長方形を描く
                g.DrawRectangle(pen, point.X, point.Y, 2, 2);
            }

            //リソースを解放する
            g.Dispose();

            return _bitmap;
        }

        private static System.Drawing.Point GetRandomPoint()
        {
            Random r1 = new System.Random();
            return new(r1.Next(0, 639) * 20, r1.Next(0, 639) * 20);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject); // gdi32.dllのDeleteObjectメソッドの使用を宣言する。
    }
}
