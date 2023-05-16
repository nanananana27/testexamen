using System;
using System.Collections.Generic;
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

namespace testexamen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int roleUser;
        public string stctd = "0";
        public string forId = "0";
        public MainWindow()
        {
            InitializeComponent();
            OpenPages(pages.entrance);
        }

        public enum pages
        {
            entrance,
            product
        }

        public void OpenPages(pages _pages)
        {
            if (_pages == pages.entrance) frame.Navigate(new Pages.entrancePage(this));
            if (_pages == pages.product) frame.Navigate(new Pages.productPage(this));
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            OpenPages(pages.entrance);
            fio.Content = "";
        }

        public void OpenProduct(string n)
        {
            new Windows.addProducts(this, n).ShowDialog();
        }
    }
}
