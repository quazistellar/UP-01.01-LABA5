using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Country.xaml
    /// </summary>
    public partial class Country : Page
    {
        CountryOfMadeTableAdapter ctnr = new CountryOfMadeTableAdapter();
        public Country()
        {
            InitializeComponent();


            MinHeight = 450;
            MinWidth = 800;

            container_pages.ItemsSource = ctnr.GetData();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название страны";
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write1.Text = "";

            try
            {
                if (container_pages.SelectedItem != null)

                {
                    DataRowView row = (DataRowView)container_pages.SelectedItem;
                    write1.Text = row["NameOfCountry"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Запись не была выбрана", Title = "Ошибка в выборе записи");
            }


            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название страны";
        }

        private void add_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в название страны!");
                return;
            }
            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми";
                return;
            }

            if (!write1.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Нельзя вводить другие символы в название страны!");
                return;
            }

            if (write1.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в название страны!");
                return;
            }

            try
            {
                ctnr.InsertQueryCountry(write1.Text.Trim());
                container_pages.ItemsSource = ctnr.GetData();
                write1.Text = "";

            }
            catch (Exception ex)
            {
                message.Text = "Такая запись уже есть в таблице!";
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название страны";
        }

        private void edit_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Нельзя вводить цифры в название страны!");
                return;
            }
            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми";
                return;
            }

            if (!write1.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Нельзя вводить другие символы в название страны!");
                return;
            }

            if (write1.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в название страны!");
                return;
            }

            try
            {
                if (write1.Text != string.Empty)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    ctnr.UpdateQueryCountry(write1.Text.Trim(), Convert.ToInt32(id));
                    container_pages.ItemsSource = ctnr.GetData();
                }
            }

            catch
            {
                MessageBox.Show("Такая запись уже есть или введенные данные были пустые", Title = "Ошибка изменения");
            }





            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название страны";
        }

        private void delete_admin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                ctnr.DeleteQueryCountry(Convert.ToInt32(id));
                container_pages.ItemsSource = ctnr.GetData();
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
            container_pages.Columns[1].Header = "Название страны";
        }
    }
}
