using BD;
using System.Windows;
using System.Windows.Controls;

namespace testexamen.Pages
{
    /// <summary>
    /// Логика взаимодействия для entrancePage.xaml
    /// </summary>
    public partial class entrancePage : Page
    {
        MainWindow mainWindow;
        public entrancePage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            WorkingBD.LoadDataBase();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            bool inputError = false;
            for (int i = 0; i < WorkingBD.clUser.Count; i++)
            {
                if (tb_login.Text == WorkingBD.clUser[i].login && tb_pwd.Text == WorkingBD.clUser[i].pwd)
                {
                    WorkingBD.user = WorkingBD.clUser[i];
                    mainWindow.frame.Navigate(new Pages.entrancePage(mainWindow));
                    inputError = true;
                    if (WorkingBD.user.role == 1)
                    {
                        mainWindow.roleUser = 1;
                        mainWindow.OpenPages(MainWindow.pages.product);
                    }
                    if (WorkingBD.user.role == 2)
                    {
                        mainWindow.roleUser = 2;
                        mainWindow.OpenPages(MainWindow.pages.product);
                    }
                    if (WorkingBD.user.role == 3)
                    {
                        mainWindow.roleUser = 3;
                        mainWindow.OpenPages(MainWindow.pages.product);
                    }
                    mainWindow.fio.Content = WorkingBD.clUser[i].surname + " " + WorkingBD.user.name + " " + WorkingBD.user.lastname;
                }
            }
            if (inputError == false)
            {
                MessageBox.Show("Логин или пароль введен не правильно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void exit1_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPages(MainWindow.pages.product);
            mainWindow.fio.Content = "Гость";
        }
    }
}
