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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using UP_01._01.Laba_5.up_laba_5DataSetTableAdapters;

namespace UP_01._01.Laba_5
{
    /// <summary>
    /// Логика взаимодействия для Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
        RoleUserTableAdapter role = new RoleUserTableAdapter();

        public Roles()
        {
            InitializeComponent();

            container_pages.ItemsSource = role.GetData();

            MinHeight = 450;
            MinWidth = 800;

        }

        private void add_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text.Any(char.IsDigit))
            {
                message.Text = "Нельзя вводить цифры!";
                return;
            }

            if (write1.Text.Any(c => !char.IsLetter(c) && c!=' '))
            {
                MessageBox.Show("Нельзя вводить другие символы в название роли!");
                return;
            }

            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми";
                return;
            }
            try
            {
                role.InsertQueryRole(write1.Text.Trim());
                container_pages.ItemsSource = role.GetData();
                write1.Text = "";

            }
            catch (Exception ex)
            {
                message.Text = "Такая запись уже есть в таблице!";
            }
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название роли";
        }
    

        private void delete_admin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    role.DeleteQueryRole(Convert.ToInt32(id));
                    container_pages.ItemsSource = role.GetData();
                }
                else
                {
                    MessageBox.Show("Ошибка: запись для удаления не была выбрана!");
                }
            }

            catch
            {
                MessageBox.Show("запись для удаления не была выбрана или\nвыбранная запись уже используется в другой таблице!", Title="Ошибка удаления");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название роли";
        }

        private void edit_admin_Click(object sender, RoutedEventArgs e)
        {

            if (write1.Text.Any(c => !char.IsLetter(c) && c!=' '))
            {
                MessageBox.Show("Нельзя вводить другие символы в названии роли!");
                return;
            }


            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми";
                return;
            }

            try
            {
                if (write1.Text != string.Empty)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    role.UpdateQueryRole(write1.Text.Trim(), Convert.ToInt32(id));
                    container_pages.ItemsSource = role.GetData();
                }
            }

            catch
            {
                MessageBox.Show("Такая запись уже есть или введенные данные были пустые", Title = "Ошибка изменения");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название роли";
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write1.Text = "";

            try
            {
                if (container_pages.SelectedItem != null)

                {
                    DataRowView row = (DataRowView)container_pages.SelectedItem;
                    write1.Text = row["NameRole"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Запись не была выбрана");
            }
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название роли";

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название роли";
        }

        private void write1_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
