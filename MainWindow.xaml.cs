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


using UP_01._01.Laba_5.up_laba_5DataSetTableAdapters;


namespace UP_01._01.Laba_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserDataTableAdapter data = new UserDataTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            MinHeight = 340;
            MinWidth = 450;

        }

        private void autorize_Click(object sender, RoutedEventArgs e)
        {
            var allogins = data.GetData().Rows;
            bool isAuthorized = false;

            for (int i = 0; i < allogins.Count; i++)
            {
                if (allogins[i][1].ToString() == LoginTbx.Text.Trim() 
                    && allogins[i][2].ToString() == PasswordTbx.Password.Trim())
                {
                    int roleId = (int)allogins[i][3];
                    isAuthorized = true;

                    switch (roleId)
                    {
                        case 1:
                            AdminWindow admin = new AdminWindow();
                            admin.ShowDialog();
                            break;
                        case 2:
                            SotrydnikWindow sotrydnik = new SotrydnikWindow();
                            sotrydnik.ShowDialog();
                            break;
                        case 3:
                            UserWindow user = new UserWindow();
                            user.ShowDialog();
                            break;
                        default:
                            MessageBox.Show("Ошибка");
                            break;
                    }
                }
            }

            if (!isAuthorized)
            {
                MessageBox.Show("Неправильный логин или пароль. Пожалуйста, попробуйте снова.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
