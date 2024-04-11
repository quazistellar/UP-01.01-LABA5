using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для UserData.xaml
    /// </summary>
    public partial class UserData : Page
    {
        UserDataTableAdapter datas = new UserDataTableAdapter();
        RoleUserTableAdapter role = new RoleUserTableAdapter();

        public UserData()
        {
            InitializeComponent();

            MinHeight = 550;
            MinWidth = 800;


            container_pages.ItemsSource = datas.GetFullData();

            role_cbx.ItemsSource = role.GetData();
            role_cbx.DisplayMemberPath = "NameRole";

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

           

            if (write_log.Text.Length < 3)
            {

                MessageBox.Show("Длина логина должна быть хотя бы 3 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }


            if (write_pass.Text.Length < 3)
            {

                MessageBox.Show("Длина пароля должна быть хотя бы 3 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }


            if (write_log.Text.Trim() == "" || string.IsNullOrWhiteSpace(write_log.Text.Trim()) || write_pass.Text.Trim() == "" || (write_pass.Text.Trim() == "" && write_log.Text.Trim() == "")) 
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }

            try
            {

                if (role_cbx.SelectedItem != null)
            {
                if (role_cbx.SelectedItem is DataRowView selectedRole)
                {
                    int selectedRoleId = Convert.ToInt32(selectedRole["ID_RoleUser"]);
                    datas.InsertQueryData(write_log.Text.Trim(), write_pass.Text.Trim(), selectedRoleId);
                    container_pages.ItemsSource = datas.GetFullData();
                }
                else
                {
                    MessageBox.Show("Выберите роль пользователя");
                }

            }
            else
            {
                MessageBox.Show("Выберите роль пользователя");
            }

        }
            catch (Exception ex)
            {
                MessageBox.Show("Такая запись уже есть в таблице!");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Логин";
            container_pages.Columns[2].Header = "Пароль";
            container_pages.Columns[4].Header = "Название роли";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
    


        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
     
            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow && role_cbx.SelectedItem is DataRowView selectedRole)
                {
                        int selectedId = Convert.ToInt32(selectedRow["ID_UserData"]);
                        int selectedRoleId = Convert.ToInt32(selectedRole["ID_RoleUser"]);
                        int id = Convert.ToInt32(selectedRow.Row[0]);
                        datas.UpdateQueryData(write_log.Text.Trim(), write_pass.Text.Trim(), selectedRoleId, id);
                        container_pages.ItemsSource = datas.GetFullData();
                    
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
            container_pages.Columns[1].Header = "Логин";
            container_pages.Columns[2].Header = "Пароль";
            container_pages.Columns[4].Header = "Название роли";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
          

            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    datas.DeleteQueryData(Convert.ToInt32(id));
                    container_pages.ItemsSource = datas.GetFullData();
                }
                else
                {
                    MessageBox.Show("Запись для удаления не была выбрана!!!");
                }
            }

            catch
            {
                MessageBox.Show("запись для удаления не была выбрана или уже используется в другой таблице!", Title = "Ошибка удаления");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Логин";
            container_pages.Columns[2].Header = "Пароль";
            container_pages.Columns[4].Header = "Название роли";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;

        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            write_log.Text = "";
            write_pass.Text = "";
            write_log.Text = "";
            write_pass.Text = "";
            role_cbx.Text = "";

            try
            {
                if (container_pages.SelectedItem != null)

                {
                    DataRowView row = (DataRowView)container_pages.SelectedItem;
                    write_log.Text = row["LoginUser"].ToString();
                    write_pass.Text = row["PasswordUser"].ToString();
                    
                }

                if (container_pages.SelectedItem is DataRowView selectedRow)
                {
                    int roleId = Convert.ToInt32(selectedRow["RoleUser_ID"]); 
                    foreach (DataRowView item in role_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_RoleUser"]) == roleId)
                        {
                            role_cbx.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Запись не была выбрана");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Логин";
            container_pages.Columns[2].Header = "Пароль";
            container_pages.Columns[4].Header = "Название роли";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Логин";
            container_pages.Columns[2].Header = "Пароль";
            container_pages.Columns[4].Header = "Название роли";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
        }

     
    }
}
