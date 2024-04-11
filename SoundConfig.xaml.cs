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
    /// Логика взаимодействия для SoundConfig.xaml
    /// </summary>
    public partial class SoundConfig : Page
    {
        SoundConfigurationTableAdapter sound = new SoundConfigurationTableAdapter();
        public SoundConfig()
        {
            InitializeComponent();

            MinHeight = 450;
            MinWidth = 800;

            container_pages.ItemsSource = sound.GetData();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название конфигурации звукоснимателей";
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write1.Text = "";

            try
            {
                if (container_pages.SelectedItem != null)

                {
                    DataRowView row = (DataRowView)container_pages.SelectedItem;
                    write1.Text = row["NameOfConfiguration"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Запись не была выбрана", Title = "Ошибка в выборе записи");

            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название конфигурации звукоснимателей";
        }

        private void add_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми";
                return;
            }

            try
            {
                sound.InsertQuerySound(write1.Text.Trim());
                container_pages.ItemsSource = sound.GetData();
                write1.Text = "";

            }
            catch (Exception ex)
            {
                message.Text = "Такая запись уже есть в таблице!";
            }


            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название конфигурации звукоснимателей";
        }

        private void edit_admin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (write1.Text != string.Empty)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    sound.UpdateQuerySound(write1.Text.Trim(), Convert.ToInt32(id));
                    container_pages.ItemsSource = sound.GetData();
                }
            }

            catch
            {
                MessageBox.Show("Такая запись уже есть или введенные данные были пустые", Title = "Ошибка изменения");
            }


            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название конфигурации звукоснимателей";
        }

        private void delete_admin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                sound.DeleteQuerySound(Convert.ToInt32(id));
                container_pages.ItemsSource = sound.GetData();
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
            container_pages.Columns[1].Header = "Название конфигурации звукоснимателей";
        }
    }
}
