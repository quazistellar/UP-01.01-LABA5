using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        UserDataTableAdapter datas = new UserDataTableAdapter();
        ClientsTableAdapter clients = new ClientsTableAdapter();
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        public Clients()
        {
            InitializeComponent();

            container_pages.ItemsSource = clients.GetFullData();

            MinHeight = 550;
            MinWidth = 800;

            role_cbx.ItemsSource = datas.GetData();
            role_cbx.DisplayMemberPath = "LoginUser";

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя клиента";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Header = "Логин клиента";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            write_log.Text = "";
            write_pass.Text = "";
            write_patronymic.Text = "";
            role_cbx.SelectedItem = null;

            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow)
                {
                    write_log.Text = selectedRow["NameClient"].ToString();
                    write_pass.Text = selectedRow["SurnameClient"].ToString();
                    write_patronymic.Text = selectedRow["PatronymicClient"].ToString();

                    int roleId = Convert.ToInt32(selectedRow["UserData_ID"]);


                    foreach (DataRowView item in role_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_UserData"]) == roleId)
                        {
                            role_cbx.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите запись!");
            }
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя клиента";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Header = "Логин клиента";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            if (write_log.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в имя!");
                return;
            }

            if (write_pass.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в фамилию!");
                return;
            }

            if (write_patronymic.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в отчество!");
                return;
            }

            if (write_log.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в имя");
                return;
            }

            if (write_pass.Text.Trim().Any(c => !char.IsLetter(c) && c != ' '))
            {
                MessageBox.Show("Нельзя вводить другие символы в фамилию");
                return;
            }

            if (write_patronymic.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в отчество");
                return;
            }

            if (string.IsNullOrWhiteSpace(write_log.Text.Trim()) || string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || (write_pass.Text.Trim() == "" && write_log.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }

            try
            {
                if (role_cbx.SelectedItem != null && role_cbx.SelectedItem is DataRowView selectedRole)
                {
                    int selectedRoleId = Convert.ToInt32(selectedRole["ID_UserData"]);

                    DataTable dataTable = employees.GetFullData();

                    string selectedRoled = role_cbx.SelectedItem.ToString();

               
                        try
                        {
                      

                        string selectedLogin = role_cbx.SelectedItem.ToString();

                        List<string> allLogins = datas.GetData().Select(user => user.LoginUser).ToList();

                        if (allLogins.Contains(selectedLogin))
                        {
                            MessageBox.Show("Ошибка: Выбранный логин уже занят", "Ошибка");
                        }
                        else
                        {
                            clients.InsertQueryClients(write_log.Text.Trim(), write_pass.Text.Trim(), write_patronymic.Text.Trim(), selectedRoleId);
                            container_pages.ItemsSource = clients.GetFullData();
                        }


                    }
                        catch
                        {
                            MessageBox.Show("Логин занят!!");
                        }

                        container_pages.ItemsSource = clients.GetFullData();
                    }
                
                else
                {
                    MessageBox.Show("Выберите логин пользователя");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Такая запись уже есть в таблице/вы вообще ничего не выбрали/логин занят!!!");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя клиента";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Header = "Логин клиента";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;


        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(write_log.Text.Trim()) || string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || (write_pass.Text.Trim() == "" && write_log.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }


            if (write_log.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в имя!");
                return;
            }



            if (write_pass.Text.Trim().Any(c => !char.IsLetter(c) && c != ' '))
            {
                MessageBox.Show("Нельзя вводить другие символы в фамилию");
                return;
            }

            if (write_patronymic.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в отчество!");
                return;
            }

            if (write_log.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в имя");
                return;
            }

            if (write_pass.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в фамилию");
                return;
            }

            if (write_patronymic.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в отчество");
                return;
            }

            if (string.IsNullOrWhiteSpace(write_log.Text.Trim()) || string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || (write_pass.Text.Trim() == "" && write_log.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }


            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow && role_cbx.SelectedItem is DataRowView selectedRole)
                {
                    int selectedId = Convert.ToInt32(selectedRow["ID_Client"]);
                    int selectedRoleId = Convert.ToInt32(selectedRole["ID_UserData"]);
           
                    clients.UpdateQueryClients(write_log.Text.Trim(), write_pass.Text.Trim(), write_patronymic.Text.Trim(), selectedRoleId, selectedId);
                    container_pages.ItemsSource = clients.GetFullData();
                }
                else
                {
                    MessageBox.Show("Выберите запись и роль пользователя для изменения");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при изменении данных");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя клиента";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Header = "Логин клиента";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    clients.DeleteQueryClients(Convert.ToInt32(id));
                    container_pages.ItemsSource = clients.GetFullData();
                }
                else
                {
                    MessageBox.Show("Запись для удаления не была выбрана!");
                }
            }

            catch
            {
                MessageBox.Show("Запись для удаления не была выбрана или ее невозможно удалить!", Title = "Ошибка удаления");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя клиента";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Header = "Логин клиента";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
        }
    }
}
