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
        private ImagePrinter _printer;

        public MainWindow()
        {
            InitializeComponent();

            _printer = new ImagePrinter(image);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool[,] sampleValues = new bool[640, 640];

            // 対角線
            for (int i = 0; i < 640; i++)
            {
                sampleValues[i, i] = true;
            }

            // 一部ブロック
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sampleValues[i, j] = true;
                }
            }

            // 一部ブロック
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    sampleValues[200 + i, j] = true;
                    sampleValues[i, 300 + j] = true;
                    sampleValues[400 + i, 400 + j] = true;
                }
            }

            _printer.Print(sampleValues);
        }
    }
}
