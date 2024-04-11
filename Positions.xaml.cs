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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP_01._01.Laba_5.up_laba_5DataSetTableAdapters;

namespace UP_01._01.Laba_5
{
    /// <summary>
    /// Логика взаимодействия для Positions.xaml
    /// </summary>
    public partial class Positions : Page
    {
        PositionsEmployeesTableAdapter positions = new PositionsEmployeesTableAdapter();
        public Positions()
        {
            InitializeComponent();
            MinHeight = 450;
            MinWidth = 800;

            posit.ItemsSource = positions.GetData();

        }

        private void add_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text.Any(char.IsDigit))
            {
                message.Text = "Нельзя вводить цифры в должность!";
                return;
            }

            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми!";
                return;
            }


            if (write1.Text.Trim().Any(c => !char.IsLetter(c) && c != ' ' && c != '-'))
            {
                MessageBox.Show("Нельзя вводить другие символы в название должности сотрудника, кроме букв, пробела и тире!");
                return;
            }


            if (write1.Text.Length < 2)
            {

                MessageBox.Show("Длина должности должна быть хотя бы 2 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }

            try
            {
                positions.InsertQueryPositions(write1.Text.Trim());
                posit.ItemsSource = positions.GetData();
                write1.Text = "";

            }
            catch (Exception ex)
            {
                message.Text = "Такая запись уже есть в таблице!";
            }

            posit.Columns[0].Visibility = Visibility.Collapsed;
            posit.Columns[1].Header = "Название должности";
        }

        private void edit_admin_Click(object sender, RoutedEventArgs e)
        {
            if (write1.Text.Any(char.IsDigit))
            {
                message.Text = "Нельзя вводить цифры в должность!";
                return;
            }

            if (write1.Text == "" || string.IsNullOrWhiteSpace(write1.Text))
            {
                message.Text = "Данные не могут быть пустыми!";
                return;
            }


            if (write1.Text.Trim().Any(c => !char.IsLetter(c) && c != ' ' && c != '-'))
            {
                MessageBox.Show("Нельзя вводить другие символы в название должности сотрудника, кроме букв, пробела и тире!");
                return;
            }

            if (write1.Text.Length < 2)
            {

                MessageBox.Show("Длина должности должна быть хотя бы 2 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }

            try
            {
                if (write1.Text != string.Empty)
                {
                    object id = (posit.SelectedItem as DataRowView).Row[0];
                    positions.UpdateQueryPosition(write1.Text.Trim(), Convert.ToInt32(id));
                    posit.ItemsSource = positions.GetData();
                }
            }

            catch
            {
                MessageBox.Show("Такая запись уже есть или введенные данные были пустые", Title = "Ошибка изменения");
            }

            posit.Columns[0].Visibility = Visibility.Collapsed;
            posit.Columns[1].Header = "Название должности";
        }

        private void delete_admin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (posit.SelectedItem != null)
                {
                    object id = (posit.SelectedItem as DataRowView).Row[0];
                positions.DeleteQueryPosition(Convert.ToInt32(id));
                posit.ItemsSource = positions.GetData();
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

            posit.Columns[0].Visibility = Visibility.Collapsed;
            posit.Columns[1].Header = "Название должности";
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write1.Text = "";

            try
            {
                if (posit.SelectedItem != null)

                {
                    DataRowView row = (DataRowView)posit.SelectedItem;
                    write1.Text = row["NameOfPositionEmployees"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Запись не была выбрана", Title="Ошибка в выборе записи");
            }

            posit.Columns[0].Visibility = Visibility.Collapsed;
            posit.Columns[1].Header = "Название должности";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            posit.Columns[0].Visibility = Visibility.Collapsed;
            posit.Columns[1].Header = "Название должности";

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
