using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для Checks.xaml
    /// </summary>
    public partial class Checks : Page

    {

        OrdersTableAdapter order = new OrdersTableAdapter();


        public static int item;
        public static int num = 0;
        public Checks()
        {
            InitializeComponent();
            
         

            datagrid.ItemsSource = order.GetData();
        }

        private void Zakazis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (Zakazis.SelectedItem != null)
                {
                    Zakazis.SelectedItem = item;
                }
                else
                {
                    MessageBox.Show("Выберите заказ для сохранения!");
                }
            }
            catch
            {
                MessageBox.Show("Выберите заказ для сохранения!!");
            }
        }

        private void add_za_Click(object sender, RoutedEventArgs e)
        {
           
            if (datagrid.SelectedItem != null)
            {
        
                DataRowView selectedRow = (DataRowView)datagrid.SelectedItem;


                string rowContent = $"<Muztorg>\nКоличество гитар: {selectedRow["AmountGuitars"]}, Дата заказа: {selectedRow["DateOfMadeOrder"]}, Общая стоимость: {selectedRow["TotalPrice"]}, Номер заказа: {selectedRow["NumberOfOrder"]}";


                Zakazis.Items.Add(rowContent.ToString()); 

                MessageBox.Show("Выбранный заказ успешно добавлен!");
            }
            else
            {
                MessageBox.Show("Выберите элемент для добавления!");
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                datagrid.SelectedItem = item;
            }
            else
            {
                MessageBox.Show("Выберите заказ для сохранения!");
            }
        }

        private void load_check_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Zakazis.SelectedItem != null)
                {
                    string selectedItem = Zakazis.SelectedItem.ToString();

                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string fileName = $"zakaz{num + 1}.txt";

                    string filePath = System.IO.Path.Combine(desktopPath, fileName);

                    File.WriteAllText(filePath, selectedItem);

                    MessageBox.Show("Заказ успешно сохранен в файл на рабочем столе!");
                }
                else
                {
                    MessageBox.Show("Выберите заказ для сохранения!!");
                }
            }
            catch
            {
                MessageBox.Show("Выберите заказ для сохранения!!");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid.Columns[0].Visibility = Visibility.Collapsed;
            datagrid.Columns[1].Header = "Количество гитар";
            datagrid.Columns[2].Visibility = Visibility.Collapsed;
            datagrid.Columns[3].Visibility = Visibility.Collapsed;
            datagrid.Columns[4].Header = "Дата совершения заказа";
            datagrid.Columns[5].Header = "Стоимость всего заказа";
            datagrid.Columns[6].Visibility = Visibility.Collapsed;
            datagrid.Columns[7].Header = "Номер заказа";
            datagrid.Columns[8].Visibility = Visibility.Collapsed;
        }
    }
}
