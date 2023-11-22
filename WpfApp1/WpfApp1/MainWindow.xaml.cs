using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



            //200x100サイズのImageオブジェクトを作成する
            Bitmap img = new Bitmap(600, 300);

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(img);

            //全体を黒で塗りつぶす
            g.FillRectangle(System.Drawing.Brushes.Black, g.VisibleClipBounds);
            //黄色い扇形を描画する
            g.DrawPie(Pens.Yellow, 60, 10, 80, 80, 30, 300);

            //リソースを解放する
            g.Dispose();

            //作成した画像を表示する
            IntPtr hbitmap = img.GetHbitmap();
            image.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hbitmap);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject); // gdi32.dllのDeleteObjectメソッドの使用を宣言する。

    }
}
