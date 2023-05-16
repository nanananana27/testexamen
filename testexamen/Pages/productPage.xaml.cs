using BD;
using Classes;
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

namespace testexamen.Pages
{
    /// <summary>
    /// Логика взаимодействия для productPage.xaml
    /// </summary>
    public partial class productPage : Page
    {
        MainWindow mainWindow;
        public string sort = "";
        public productPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            WorkingBD.LoadDataBase();
            CreateProduct(WorkingBD.clProduct);
            check();
        }

        public void check()
        {
            if(mainWindow.roleUser == 1)
            {
                addProduct.Visibility = Visibility.Visible;
            }
            else
            {
                addProduct.Visibility = Visibility.Hidden;
            }
        }

        public void CreateProduct(List<product> _products)
        {
            var bc = new BrushConverter();
            parrent.Children.Clear();
            Label countProduct = new Label();
            countProduct.Foreground = (Brush)bc.ConvertFrom("#498c51");
            countProduct.HorizontalAlignment = HorizontalAlignment.Center;
            countProduct.VerticalAlignment = VerticalAlignment.Top;
            countProduct.Margin = new Thickness(0, 0, 0, 0);
            countProduct.FontFamily = new FontFamily("Comic Sans MS");
            countProduct.FontSize = 20;
            countProduct.Content = $"{_products.Count} из {WorkingBD.clProduct.Count} товаров";
            parrent.Children.Add(countProduct);
            for (int i = 0; i <_products.Count; i++)
            {
                product product = _products[i];

                Grid grid = new Grid();
                grid.Background = (Brush)bc.ConvertFrom("#76e383");
                grid.Margin = new Thickness(10, 3, 10, 3);
                grid.Height = 230;
                parrent.Children.Add(grid);

                if (product.img_src != "")
                {
                    Image image = new Image();
                    image.Stretch = Stretch.Fill;
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Width = 170;
                    image.Height = 150;
                    image.Margin = new Thickness(15, 34, 0, 25);
                    image.Source = new BitmapImage(new Uri(product.img_src, UriKind.Relative));
                    grid.Children.Add(image);
                }
                else
                {
                    Image image = new Image();
                    image.Stretch = Stretch.Fill;
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Width = 170;
                    image.Height = 150;
                    image.Margin = new Thickness(15, 34, 0, 25);
                    image.Source = new BitmapImage(new Uri("/Images/A782R4.jpg",UriKind.Relative));
                    grid.Children.Add(image);
                }

                Label name = new Label();
                name.Content = product.name;
                name.HorizontalAlignment = HorizontalAlignment.Center;
                name.VerticalAlignment = VerticalAlignment.Top;
                name.Margin = new Thickness(331, 0, 250, 120);
                name.FontFamily = new FontFamily("Comic Sans MS");
                name.FontSize = 20;
                name.Foreground = Brushes.White;
                name.FontWeight = FontWeights.Bold;
                grid.Children.Add(name);

                Label description = new Label();
                description.Content = product.description;
                description.HorizontalAlignment = HorizontalAlignment.Left;
                description.Margin = new Thickness(280, 40, 0, 0);
                description.FontFamily = new FontFamily("Comic Sans MS");
                description.FontSize = 18;
                description.Foreground = Brushes.White;
                grid.Children.Add(description);

                Label manufacturer = new Label();
                manufacturer.Content = "Производитель: "+ product.manufacturer;
                manufacturer.HorizontalAlignment = HorizontalAlignment.Left;
                manufacturer.Margin = new Thickness(280, 70, 0, 0);
                manufacturer.FontFamily = new FontFamily("Comic Sans MS");
                manufacturer.FontSize = 18;
                manufacturer.Foreground = Brushes.White;
                grid.Children.Add(manufacturer);

                Label price = new Label();
                price.Content = "Цена: "+ product.price + "р.";
                price.HorizontalAlignment = HorizontalAlignment.Left;
                price.Margin = new Thickness(280, 100, 0, 0);
                price.FontFamily = new FontFamily("Comic Sans MS");
                price.FontSize = 18;
                price.Foreground = Brushes.White;
                grid.Children.Add(price);

                Label amount_on_warehouse = new Label();
                amount_on_warehouse.Content = "Количество на складе: " + product.amount_on_warehouse + " " + product.measure_unit;
                amount_on_warehouse.HorizontalAlignment = HorizontalAlignment.Left;
                amount_on_warehouse.Margin = new Thickness(280, 130, 0, 0);
                amount_on_warehouse.FontFamily = new FontFamily("Comic Sans MS");
                amount_on_warehouse.FontSize = 18;
                amount_on_warehouse.Foreground = Brushes.White;
                grid.Children.Add(amount_on_warehouse);

                Label discount = new Label();
                discount.Content = product.discount+"%";
                discount.HorizontalAlignment = HorizontalAlignment.Right;
                discount.Margin = new Thickness(280, 70, 30, 0);
                discount.FontFamily = new FontFamily("Comic Sans MS");
                discount.FontSize = 25;
                discount.Foreground = Brushes.White;
                grid.Children.Add(discount);

                Button upd = new Button();
                Button del = new Button();

                del.FontFamily = new FontFamily("Comic Sans MS");
                upd.FontFamily = new FontFamily("Comic Sans MS");

                if (mainWindow.roleUser == 1)
                {
                    del.Foreground = (Brush)bc.ConvertFrom("#498c51");
                    del.Content = "Удалить";
                    del.Background = Brushes.White;
                    del.Margin = new Thickness(400, 150, 0, 0);
                    del.HorizontalAlignment = HorizontalAlignment.Left; 
                    del.VerticalAlignment = VerticalAlignment.Center;
                    del.Height = 25;
                    del.Width = 100;
                    del.Tag = i;
                    del.Click += delegate
                    {
                        int sum = Convert.ToInt32(del.Tag);
                        int s = WorkingBD.clProduct[sum].id;
                        WorkingBD.Connection("DELETE FROM product WHERE id=" + s + ";");
                        WorkingBD.clProduct.RemoveAt(Convert.ToInt32(del.Tag));
                        parrent.Children.Clear();
                        CreateProduct(WorkingBD.clProduct);

                    };
                    grid.Children.Add(del);
                }

                if (mainWindow.roleUser == 1)
                {
                    upd.Foreground = (Brush)bc.ConvertFrom("#498c51");
                    upd.Content = "Изменить";
                    upd.Background = Brushes.White;
                    upd.Margin = new Thickness(280, 150, 0, 0);
                    upd.HorizontalAlignment = HorizontalAlignment.Left;
                    upd.VerticalAlignment = VerticalAlignment.Center;
                    upd.Height = 25;
                    upd.Width = 100;
                    upd.Tag = i;
                    upd.Click += delegate
                    {
                        mainWindow.forId = Convert.ToString(WorkingBD.clProduct[Convert.ToInt32(upd.Tag)].id);
                        mainWindow.stctd = Convert.ToString(Convert.ToInt32(upd.Tag));
                        mainWindow.OpenProduct(null);
                        parrent.Children.Clear();
                        CreateProduct(WorkingBD.clProduct);

                    };
                    grid.Children.Add(upd);
                }
            }
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenProduct("A");
            parrent.Children.Clear();
            CreateProduct(WorkingBD.clProduct);
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (poisk.Text == "")
            {
                CreateProduct(WorkingBD.clProduct);
            }
            else
            {
                List<product> products = new List<product>();
                products = WorkingBD.clProduct.FindAll(x => x.name.ToLower().Contains(poisk.Text.ToLower()));
                CreateProduct(products);
            }
        }

        private void mix_Click(object sender, RoutedEventArgs e)
        {
            WorkingBD.clProduct = WorkingBD.clProduct.OrderBy(x => x.price).ToList();
            sort = "min";
            CreateProduct(WorkingBD.clProduct);
        }

        private void max_Click(object sender, RoutedEventArgs e)
        {
            WorkingBD.clProduct = WorkingBD.clProduct.OrderBy(x => x.price).Reverse().ToList();
            sort = "max";
            CreateProduct(WorkingBD.clProduct);
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            sort = "";
            mainWindow.OpenPages(MainWindow.pages.product);
        }
    }
}
