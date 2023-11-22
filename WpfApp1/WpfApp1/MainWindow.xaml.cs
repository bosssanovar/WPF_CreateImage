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
            image.Visibility = Visibility.Hidden;
            _printer.Print();
            image.Visibility = Visibility.Visible;
        }
    }
}
