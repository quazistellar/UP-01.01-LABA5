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
using UP_01._01.Laba_5.Model;
using UP_01._01.Laba_5.up_laba_5DataSetTableAdapters;

namespace UP_01._01.Laba_5
{
    /// <summary>
    /// Логика взаимодействия для VidGuitar.xaml
    /// </summary>
    public partial class VidGuitar : Page
    {
      
        VidGuitarTableAdapter vid = new VidGuitarTableAdapter();
        public VidGuitar()
        {
            InitializeComponent();

            MinHeight = 450;
            MinWidth = 800;

            container_pages.ItemsSource = vid.GetData();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название вида гитары";
         
        }

        private void add_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры!");
                return;
            }

            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми";
                return;
            }

            if (write1.Text.Length < 2)
            {

                MessageBox.Show("Длина вида должна быть хотя бы 2 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }

            if (write1.Text.Trim().Any(c => !char.IsLetter(c) && c != ' ' && c != '-'))
            {
                MessageBox.Show("Нельзя вводить другие символы в название вида гитары");
                return;
            }

            try
            {
                vid.InsertQueryVidGuitar(write1.Text.Trim());
                container_pages.ItemsSource = vid.GetData();
                write1.Text = "";

            }
            catch (Exception ex)
            {
                message.Text = "Такая запись уже есть в таблице!";
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название вида гитары";
        }

        private void edit_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры!");
                return;
            }

            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми";
                return;
            }


            if (write1.Text.Length < 2)
            {

                MessageBox.Show("Длина вида должна быть хотя бы 2 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }

            try
            {
                if (write1.Text != string.Empty)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    vid.UpdateQueryVidGuitar(write1.Text.Trim(), Convert.ToInt32(id));
                    container_pages.ItemsSource = vid.GetData();
                }
            }

            catch
            {
                MessageBox.Show("Такая запись уже есть или введенные данные были пустые", Title = "Ошибка изменения");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название вида гитары";
        }

        private void delete_admin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                vid.DeleteQueryVidGuitar(Convert.ToInt32(id));
                container_pages.ItemsSource = vid.GetData();
                }
                else
                {
                    MessageBox.Show("Зпись для удаления не была выбрана!");
                }
            }

            catch
            {
                MessageBox.Show("запись для удаления не была выбрана или\nвыбранная запись уже используется в другой таблице!", Title = "Ошибка удаления");
            }


            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название вида гитары";
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write1.Text = "";

            try
            {
                if (container_pages.SelectedItem != null)

                {
                    DataRowView row = (DataRowView)container_pages.SelectedItem;
                    write1.Text = row["NameOfVidGuitar"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Запись не была выбрана", Title = "Ошибка в выборе записи");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название вида гитары";
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            List<vidModel> forImport = LabaConverter.Deserialize0bject<List<vidModel>>();

            try
            {
                foreach (var item in forImport)
                {
                    vid.InsertQueryVidGuitar(item.NameOfVidGuitar);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при импорте!");
            }

            container_pages.ItemsSource = null;
            container_pages.ItemsSource = vid.GetData();

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название вида гитары";
        }
    }
}
