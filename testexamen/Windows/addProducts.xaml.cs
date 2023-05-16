using BD;
using Classes;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace testexamen.Windows
{
    /// <summary>
    /// Логика взаимодействия для addProducts.xaml
    /// </summary>
    public partial class addProducts : Window
    {
        MainWindow mainWindow;
        public string main;
        public string s_src = "";
        public addProducts(MainWindow _mainWindow, string _main)
        {
            InitializeComponent(); 
            mainWindow = _mainWindow;
            main = _main;
            WorkingBD.LoadDataBase();
            for (int i = 0; i < WorkingBD.clCategory.Count; i++)
            {
                tb_category_id.Items.Add(WorkingBD.clCategory[i].id);
            }

            if (main != null)
            {
                upd.Visibility = Visibility.Hidden;
            }
            else
            {
                add.Visibility = Visibility.Hidden;
                LoadPass(WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)]);
            }
        }

        public bool CharLetters(string a)
        {
            bool b = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsLetter(a, i) == false) b = false;
            }
            return b;
        }

        // проверка на цифры
        public bool CharNumbers(string a)
        {
            bool b = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsNumber(a, i) == false) b = false;
            }
            return b;
        }

        public void LoadPass(product product)
        {
            tb_article.Text = Convert.ToString(product.article);
            tb_name.Text = Convert.ToString(product.name);
            tb_measure_unit.Text = Convert.ToString(product.measure_unit);
            tb_price.Text = Convert.ToString(product.price);
            tb_max_discount.Text = Convert.ToString(product.max_discount);
            tb_manufacturer.Text = Convert.ToString(product.manufacturer);
            tb_supplier.Text = Convert.ToString(product.supplier);
            tb_category_id.Text = Convert.ToString(product.category_id);
            tb_discount.Text = Convert.ToString(product.discount);
            tb_amount_on_warehouse.Text = Convert.ToString(product.amount_on_warehouse);
            tb_description.Text = Convert.ToString(product.description);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(tb_article.Text != "")
            {
                if (tb_name.Text != "")
                {
                    if (tb_measure_unit.Text != "")
                    {
                        if (tb_price.Text != "")
                        {
                            if (tb_max_discount.Text != "" && CharNumbers(tb_max_discount.Text))
                            {
                                if (tb_manufacturer.Text != "")
                                {
                                    if (tb_supplier.Text != "")
                                    {
                                        if (tb_category_id.SelectedIndex > -1)
                                        {
                                            if (tb_discount.Text != "")
                                            {
                                                if (tb_amount_on_warehouse.Text != "")
                                                {
                                                    if (tb_description.Text != "")
                                                    {
                                                        product newProduct = new product();
                                                        newProduct.article = tb_article.Text;
                                                        newProduct.name = tb_name.Text;
                                                        newProduct.measure_unit = tb_measure_unit.Text;
                                                        newProduct.price = Convert.ToInt32(tb_price.Text);
                                                        newProduct.max_discount = Convert.ToInt32(tb_max_discount.Text);
                                                        newProduct.manufacturer = tb_manufacturer.Text;
                                                        newProduct.supplier = tb_supplier.Text;
                                                        newProduct.category_id = Convert.ToInt32(tb_category_id.Text);
                                                        newProduct.discount = Convert.ToInt32(tb_discount.Text);
                                                        newProduct.amount_on_warehouse = Convert.ToInt32(tb_amount_on_warehouse.Text);
                                                        newProduct.description = tb_description.Text;
                                                        newProduct.id = Convert.ToInt32(WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].id) + 1;
                                                        newProduct.img_src = s_src;
                                                        WorkingBD.clProduct.Add(newProduct);

                                                        WorkingBD.Connection("insert into product values (" +
                                                            WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].id + ",'"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].article + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].name + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].measure_unit + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].price + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].max_discount + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].manufacturer + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].supplier + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].category_id + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].discount + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].amount_on_warehouse + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].description + "','"
                                                            + WorkingBD.clProduct[WorkingBD.clProduct.Count - 1].img_src + "');");
                                                        this.Close();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void add_img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "c:\\";
            file.Filter = "PNG (*.png)|*.png|All files(*.*)|*.*";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.ShowDialog();
            if(file.FileName != "")
            {
                s_src = file.FileName;
                string[] array = s_src.Split('\\');
                int index = 0;
                for(int i = 0; i < array.Length; i++)
                {
                    if (array[i] == "Images") index = i;
                }
                s_src = "/testexamen;component/" + array[index] + "/" + array[index + 1];
                src.Source = new BitmapImage(new Uri(s_src, UriKind.Relative));
            }
        }

        private void upd_Click(object sender, RoutedEventArgs e)
        {
            if (tb_article.Text != "")
            {
                if (tb_name.Text != "")
                {
                    if (tb_measure_unit.Text != "")
                    {
                        if (tb_price.Text != "")
                        {
                            if (tb_max_discount.Text != "")
                            {
                                if (tb_manufacturer.Text != "")
                                {
                                    if (tb_supplier.Text != "")
                                    {
                                        if (tb_category_id.SelectedIndex > -1)
                                        {
                                            if (tb_discount.Text != "")
                                            {
                                                if (tb_amount_on_warehouse.Text != "")
                                                {
                                                    if (tb_description.Text != "")
                                                    {
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].article = tb_article.Text;
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].name = tb_name.Text;
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].measure_unit = tb_measure_unit.Text;
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].price = Convert.ToInt32(tb_price.Text);
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].max_discount = Convert.ToInt32(tb_max_discount.Text);
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].manufacturer = tb_manufacturer.Text;
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].supplier = tb_supplier.Text;
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].category_id = Convert.ToInt32(tb_category_id.Text);
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].discount = Convert.ToInt32(tb_discount.Text);
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].amount_on_warehouse = Convert.ToInt32(tb_amount_on_warehouse.Text);
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].description = tb_description.Text;
                                                        WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].img_src = s_src;

                                                        WorkingBD.Connection("update product set article ='"
                                                            + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].article +
                                                            "',name='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].name +
                                                            "',measure_unit='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].measure_unit +
                                                            "',price='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].price +
                                                            "',max_discount='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].max_discount +
                                                            "',manufacturer='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].manufacturer +
                                                            "',supplier='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].supplier +
                                                            "',category_id='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].category_id +
                                                            "',discount='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].discount +
                                                            "',amount_on_warehouse='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].amount_on_warehouse +
                                                            "',description='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].description +
                                                            "',img_src='" + WorkingBD.clProduct[Convert.ToInt32(mainWindow.stctd)].img_src +
                                                            "' where id=" + Convert.ToInt32(mainWindow.forId) + ";"
                                                            );
                                                        

                                                        this.Close();
                                                    }    
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
