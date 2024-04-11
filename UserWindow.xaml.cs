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
using System.Windows.Shapes;
using UP_01._01.Laba_5.up_laba_5DataSetTableAdapters;

namespace UP_01._01.Laba_5
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        GuitarsTableAdapter guitarsTable = new GuitarsTableAdapter();
        OrdersTableAdapter orders = new OrdersTableAdapter(); 

        List<GuitarModel> list_gui = new List<GuitarModel>();

        public static decimal summa_pokupki = 0;
        public static int num = 0;
        public static int checkk = 0;
        public UserWindow()
        {
            InitializeComponent();

            summa_pokupki = 0;

            tovariDG.ItemsSource = guitarsTable.GetData(); 

            pokupkaDG.ItemsSource = list_gui;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            tovariDG.Columns[0].Visibility = Visibility.Collapsed;
            tovariDG.Columns[1].Header = "Название гитары";
            tovariDG.Columns[2].Header = "Цена гитары";
            tovariDG.Columns[3].Visibility = Visibility.Collapsed;
            tovariDG.Columns[4].Visibility = Visibility.Collapsed;
            tovariDG.Columns[5].Visibility = Visibility.Collapsed;
            tovariDG.Columns[6].Visibility = Visibility.Collapsed;
            tovariDG.Columns[7].Visibility = Visibility.Collapsed;

            pokupkaDG.Columns[0].Header = "Название гитары";
            pokupkaDG.Columns[1].Header = "Цена гитары";
        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {

            schet.Text = summa_pokupki.ToString();

            //summa_tbx.Text.Trim() !=string.Empty

            if (tovariDG.SelectedItem != null)
            {

                if (tovariDG.SelectedItem is DataRowView selectedRow)
                {
                    string name = selectedRow["NameGuitar"].ToString();
                    decimal price = (decimal)selectedRow["PriceGuitar"];

                    GuitarModel guitarModel = new GuitarModel
                    {
                        name = name,
                        price = price
                    };

                    list_gui.Add(guitarModel);

                    pokupkaDG.ItemsSource = null;
                    pokupkaDG.ItemsSource = list_gui;

                    summa_pokupki += price;

                    

                    MessageBox.Show("Товар успешно добавлен в покупку!");
                }
                else
                {
                    MessageBox.Show("Выберите товар для добавления в покупку!");
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для добавления в покупку и введите сумму оплаты!");
            }

            schet.Text = summa_pokupki.ToString();

            pokupkaDG.Columns[0].Header = "Название гитары";
            pokupkaDG.Columns[1].Header = "Цена гитары";

        }

        private void SaveToTxtFile(string filePath)
        {
          

            checkk++;

            StringBuilder sb = new StringBuilder();

       
            sb.AppendLine("<Muztorg>");
            sb.AppendLine($"Кассовый чек №<{checkk}>");
            sb.AppendLine();

        
            foreach (GuitarModel item in list_gui)
            {
                sb.AppendLine($"  {item.name}  -  {item.price}");
            }
            sb.AppendLine();

        
            decimal fullSum = summa_pokupki;
            sb.AppendLine($"Итого к оплате: {fullSum}");

            if (summa_tbx.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в цену гитары!");
                return;
            }

            else
            {
                decimal vneseno = Convert.ToDecimal(summa_tbx.Text.Trim());

                sb.AppendLine($"Внесено: {vneseno}");

                decimal sdacha = vneseno - fullSum;
                sb.AppendLine($"Сдача: {sdacha}");

                if (vneseno >= fullSum)
                {
                    File.WriteAllText(filePath, sb.ToString());

                    pokupkaDG.ItemsSource = null;
                    summa_tbx.Text = "";
                    summa_pokupki = 0;
                    list_gui.Clear();

                    MessageBox.Show("Чек успешно сохранен в файл на рабочем столе!");
                }
                else
                {
                    MessageBox.Show("Внесенной суммы не хватает для покупки!");
                }

            }

  
          

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            num++;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"Чек номер {num + 1}.txt";

            string filePath = System.IO.Path.Combine(desktopPath, fileName);

            if (summa_tbx.Text.Trim() != string.Empty)
            {
                SaveToTxtFile(filePath);
           
            }

            else
            {
                MessageBox.Show("Вы не ввели сумму оплаты!");
            }

           


        }

        private void pokupkaDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pokupkaDG.Columns[0].Header = "Название гитары";
            pokupkaDG.Columns[1].Header = "Цена гитары";
        }
    }
}
