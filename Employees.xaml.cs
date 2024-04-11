using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        UserDataTableAdapter datas = new UserDataTableAdapter();
        PositionsEmployeesTableAdapter positions = new PositionsEmployeesTableAdapter();

        public Employees()
        {
            InitializeComponent();

            container_pages.ItemsSource = employees.GetFullData();

            MinHeight = 550;
            MinWidth = 800;

            role_cbx.ItemsSource = datas.GetData();
            role_cbx.DisplayMemberPath = "LoginUser";

            posit_cbx.ItemsSource = positions.GetData();
            posit_cbx.DisplayMemberPath = "NameOfPositionEmployees";
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write_log.Text = "";
            write_pass.Text = "";
            write_patronymic.Text = "";
            role_cbx.SelectedItem = null;
            posit_cbx.SelectedItem = null;

            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow)
                {
                    write_log.Text = selectedRow["NameEmployee"].ToString();
                    write_pass.Text = selectedRow["SurnameEmployee"].ToString();
                    write_patronymic.Text = selectedRow["PatronymicEmployee"].ToString();

                    int roleId = Convert.ToInt32(selectedRow["UserData_ID"]);
                    int positionId = Convert.ToInt32(selectedRow["PositionsEmployees_ID"]);

                    foreach (DataRowView item in role_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_UserData"]) == roleId)
                        {
                            role_cbx.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (DataRowView item in posit_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_PositionsEmployees"]) == positionId)
                        {
                            posit_cbx.SelectedItem = item; 
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
            container_pages.Columns[1].Header = "Имя сотрудника";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Header = "Логин сотрудника";
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Header = "Должность сотрудника";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (write_log.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в имя!");
                return;
            }

            if (write_log.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в имя сотрудника!");
                return;
            }

            if (write_pass.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в фамилию сотрудника!");
                return;
            }


            if (write_patronymic.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в отчество сотрудника!");
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
                    int selectedPositionId = Convert.ToInt32(selectedRole["RoleUser_ID"]);
                    employees.InsertQueryEmp(write_log.Text.Trim(), write_pass.Text.Trim(), write_patronymic.Text.Trim(), selectedRoleId, selectedPositionId);
                    container_pages.ItemsSource = employees.GetFullData();
                }
                else
                {
                    MessageBox.Show("Выберите должность и логин пользователя");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Такая запись уже есть в таблице/вы вообще ничего не выбрали/логин занят!!!");
            }


            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя сотрудника";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Header = "Логин сотрудника";
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Header = "Должность сотрудника";
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
                MessageBox.Show("Нельзя вводить другие символы в имя сотрудника!");
                return;
            }

            if (write_pass.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в фамилию сотрудника!");
                return;
            }


            if (write_patronymic.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в отчество сотрудника!");
                return;
            }
            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow && role_cbx.SelectedItem is DataRowView selectedRole && posit_cbx.SelectedItem is DataRowView selectedPosition)
                {
                    int selectedId = Convert.ToInt32(selectedRow["ID_Employees"]);
                    int selectedRoleId = Convert.ToInt32(selectedRole["ID_UserData"]);
                    int selectedPositionId = Convert.ToInt32(selectedPosition["ID_PositionsEmployees"]);
                    employees.UpdateQueryEmp(write_log.Text.Trim(), write_pass.Text.Trim(), write_patronymic.Text.Trim(), selectedRoleId, selectedPositionId, selectedId);
                    container_pages.ItemsSource = employees.GetFullData();
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
            container_pages.Columns[1].Header = "Имя сотрудника";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Header = "Логин сотрудника";
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Header = "Должность сотрудника";
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    employees.DeleteQueryEmp(Convert.ToInt32(id));
                    container_pages.ItemsSource = employees.GetFullData();
                }
                else
                {
                    MessageBox.Show("Зпись для удаления не была выбрана!");
                }
            }

            catch
            {
                MessageBox.Show("Запись для удаления не была выбрана или ее невозможно удалить!", Title = "Ошибка удаления");
            }



            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя сотрудника";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Header = "Логин сотрудника";
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Header = "Должность сотрудника";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Имя сотрудника";
            container_pages.Columns[2].Header = "Фамилия";
            container_pages.Columns[3].Header = "Отчество";
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Header = "Логин сотрудника";
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Header = "Должность сотрудника";
        }

        private void write_log_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsDigit(c))
                {
                    e.Handled = true; 
                    break;
                }
            }
        }

        private void write_pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsDigit(c))
                {
                    e.Handled = true; 
                    break;
                }
            }
        }

        private void write_patronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsDigit(c))
                {
                    e.Handled = true; 
                    break;
                }
            }
        }
    }
}
