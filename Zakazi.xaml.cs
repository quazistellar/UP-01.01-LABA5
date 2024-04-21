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
    /// Логика взаимодействия для Zakazi.xaml
    /// </summary>
    public partial class Zakazi : Page

    {
        OrdersTableAdapter order = new OrdersTableAdapter();


        GuitarsTableAdapter guitars = new GuitarsTableAdapter();
        ClientsTableAdapter clients = new ClientsTableAdapter();
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        OrderStatusTableAdapter statuses = new OrderStatusTableAdapter();

        public Zakazi()
        {
            InitializeComponent();


            MinHeight = 550;
            MinWidth = 800;


            container_pages.ItemsSource = order.GetFullData();


            guitar_cbx.ItemsSource = guitars.GetData();
            guitar_cbx.DisplayMemberPath = "NameGuitar";


            client_cbx.ItemsSource = clients.GetData();
            client_cbx.DisplayMemberPath = "NameClient";



            employee_cbx.ItemsSource = employees.GetData();
            employee_cbx.DisplayMemberPath = "NameEmployee";


            status_cbx.ItemsSource = statuses.GetData();
            status_cbx.DisplayMemberPath = "OrderStatus";

     
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[2].Visibility = Visibility.Collapsed; 
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Количество гитар";
            container_pages.Columns[16].Header = "Название гитары";
            container_pages.Columns[17].Header = "Имя клиента";
            container_pages.Columns[4].Header = "Дата заказа";
            container_pages.Columns[5].Header = "Стоимость всего заказа";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Header = "Номер заказа";
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Visibility = Visibility.Collapsed;
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Visibility = Visibility.Collapsed;
            container_pages.Columns[15].Visibility = Visibility.Collapsed;
            container_pages.Columns[18].Visibility = Visibility.Collapsed;
            container_pages.Columns[19].Visibility = Visibility.Collapsed;
            container_pages.Columns[20].Visibility = Visibility.Collapsed;
            container_pages.Columns[21].Visibility = Visibility.Collapsed;
            container_pages.Columns[22].Header = "Имя сотрудника";
            container_pages.Columns[23].Visibility = Visibility.Collapsed;
            container_pages.Columns[24].Visibility = Visibility.Collapsed;
            container_pages.Columns[25].Visibility = Visibility.Collapsed;
            container_pages.Columns[26].Visibility = Visibility.Collapsed;
            container_pages.Columns[27].Visibility = Visibility.Collapsed;
            container_pages.Columns[28].Header = "Статус заказа";
            container_pages.Columns[29].Visibility = Visibility.Collapsed;
        }

        private void totalcost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void zakaz_num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(totalcost.Text.Trim()) || string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || (write_pass.Text.Trim() == "" && zakaz_num.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }

            if (zakaz_num.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в номер заказа!");
                return;
            }

            if (totalcost.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в стоимость!");
                return;
            }


            if (write_pass.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в количество!");
                return;
            }



            try
            {
                if (guitar_cbx.SelectedItem != null && client_cbx.SelectedItem != null && employee_cbx.SelectedItem != null
                    && status_cbx.SelectedItem != null 
                    && guitar_cbx.SelectedItem is DataRowView selectedVid && client_cbx.SelectedItem is DataRowView selectedForm
                    && employee_cbx.SelectedItem is DataRowView selectedSound && status_cbx.SelectedItem is DataRowView selectedCountry)
                {
                    int vidid = Convert.ToInt32(selectedVid["ID_Guitar"]);
                    int formid = Convert.ToInt32(selectedForm["ID_Client"]);
                    int soundid = Convert.ToInt32(selectedSound["ID_Employees"]);
                    int cntryid = Convert.ToInt32(selectedCountry["ID_OrderStatus"]);
            

                    order.InsertQueryOrder(Convert.ToInt32(write_pass.Text.Trim()), vidid, formid, datas.SelectedDate.ToString(), Convert.ToDecimal(totalcost.Text.Trim()), soundid, Convert.ToInt32(zakaz_num.Text.Trim()), cntryid);
                    container_pages.ItemsSource = order.GetFullData();
                }
                else
                {
                    if (guitar_cbx.SelectedItem == null || client_cbx.SelectedItem == null || employee_cbx.SelectedItem == null
                        || status_cbx.SelectedItem == null)
                    {
                        MessageBox.Show("Вы не выбрали запись!");
                    }
                    else if (totalcost.Text.Trim() == "")
                    {
                        MessageBox.Show("Цена не была внесена в поле");
                    }
                  
                    else
                    {
                        MessageBox.Show("Такая запись уже есть в таблице!");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении, проверьте формат/и входных данных и то, нет ли такой же записи в таблице!");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[2].Visibility = Visibility.Collapsed;
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Количество гитар";
            container_pages.Columns[16].Header = "Название гитары";
            container_pages.Columns[17].Header = "Имя клиента";
            container_pages.Columns[4].Header = "Дата заказа";
            container_pages.Columns[5].Header = "Стоимость всего заказа";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Header = "Номер заказа";
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Visibility = Visibility.Collapsed;
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Visibility = Visibility.Collapsed;
            container_pages.Columns[15].Visibility = Visibility.Collapsed;
            container_pages.Columns[18].Visibility = Visibility.Collapsed;
            container_pages.Columns[19].Visibility = Visibility.Collapsed;
            container_pages.Columns[20].Visibility = Visibility.Collapsed;
            container_pages.Columns[21].Visibility = Visibility.Collapsed;
            container_pages.Columns[22].Header = "Имя сотрудника";
            container_pages.Columns[23].Visibility = Visibility.Collapsed;
            container_pages.Columns[24].Visibility = Visibility.Collapsed;
            container_pages.Columns[25].Visibility = Visibility.Collapsed;
            container_pages.Columns[26].Visibility = Visibility.Collapsed;
            container_pages.Columns[27].Visibility = Visibility.Collapsed;
            container_pages.Columns[28].Header = "Статус заказа";
            container_pages.Columns[29].Visibility = Visibility.Collapsed;


        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (write_pass.Text.Trim().Any(c => char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в количество!");
                return;
            }

            if (totalcost.Text.Trim().Any(c => char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в цену!");
                return;
            }

            if (zakaz_num.Text.Trim().Any(c => char.IsLetter(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в номер заказа!");
                return;
            }

            if (string.IsNullOrWhiteSpace(totalcost.Text.Trim()) || string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || (write_pass.Text.Trim() == "" && zakaz_num.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми!");
                return;
            }

          

            if (string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || string.IsNullOrWhiteSpace(totalcost.Text.Trim()) || (write_pass.Text.Trim() == "" || zakaz_num.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }


            if (write_pass.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Нельзя вводить буквы!");
                return;
            }

            if (totalcost.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Нельзя вводить буквы!");
                return;
            }

            if (zakaz_num.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Нельзя вводить буквы!");
                return;
            }


            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow

                    && guitar_cbx.SelectedItem is DataRowView selectedVid && client_cbx.SelectedItem is DataRowView selectedForm
                    && employee_cbx.SelectedItem is DataRowView selectedSound && status_cbx.SelectedItem is DataRowView selectedCountry)

                {
                    int selectedId = Convert.ToInt32(selectedRow["ID_Order"]);


                    int guiid = Convert.ToInt32(selectedVid["ID_Guitar"]);
                    int cliid = Convert.ToInt32(selectedForm["ID_Client"]);
                    int empid = Convert.ToInt32(selectedSound["ID_Employees"]);
                    int ordid = Convert.ToInt32(selectedCountry["ID_OrderStatus"]);

                    try
                    {
                        order.UpdateQueryOrder(Convert.ToInt32(write_pass.Text.Trim()), guiid, cliid, datas.SelectedDate.ToString(), Convert.ToDecimal(totalcost.Text.Trim()), empid, Convert.ToInt32(zakaz_num.Text), ordid, selectedId);
                        container_pages.ItemsSource = order.GetFullData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для изменения");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при изменении данных");
            }



            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[2].Visibility = Visibility.Collapsed;
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Количество гитар";
            container_pages.Columns[16].Header = "Название гитары";
            container_pages.Columns[17].Header = "Имя клиента";
            container_pages.Columns[4].Header = "Дата заказа";
            container_pages.Columns[5].Header = "Стоимость всего заказа";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Header = "Номер заказа";
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Visibility = Visibility.Collapsed;
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Visibility = Visibility.Collapsed;
            container_pages.Columns[15].Visibility = Visibility.Collapsed;
            container_pages.Columns[18].Visibility = Visibility.Collapsed;
            container_pages.Columns[19].Visibility = Visibility.Collapsed;
            container_pages.Columns[20].Visibility = Visibility.Collapsed;
            container_pages.Columns[21].Visibility = Visibility.Collapsed;
            container_pages.Columns[22].Header = "Имя сотрудника";
            container_pages.Columns[23].Visibility = Visibility.Collapsed;
            container_pages.Columns[24].Visibility = Visibility.Collapsed;
            container_pages.Columns[25].Visibility = Visibility.Collapsed;
            container_pages.Columns[26].Visibility = Visibility.Collapsed;
            container_pages.Columns[27].Visibility = Visibility.Collapsed;
            container_pages.Columns[28].Header = "Статус заказа";
            container_pages.Columns[29].Visibility = Visibility.Collapsed;

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                    order.DeleteQueryOrder(Convert.ToInt32(id));
                    container_pages.ItemsSource = order.GetFullData();
                }
                else
                {
                    MessageBox.Show("Зпись для удаления не была выбрана!");
                }
            }

            catch
            {
                MessageBox.Show("Запись для удаления не была выбрана или её невозможно удалить!", Title = "Ошибка удаления");
            }

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[2].Visibility = Visibility.Collapsed;
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Количество гитар";
            container_pages.Columns[16].Header = "Название гитары";
            container_pages.Columns[17].Header = "Имя клиента";
            container_pages.Columns[4].Header = "Дата заказа";
            container_pages.Columns[5].Header = "Стоимость всего заказа";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Header = "Номер заказа";
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Visibility = Visibility.Collapsed;
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Visibility = Visibility.Collapsed;
            container_pages.Columns[15].Visibility = Visibility.Collapsed;
            container_pages.Columns[18].Visibility = Visibility.Collapsed;
            container_pages.Columns[19].Visibility = Visibility.Collapsed;
            container_pages.Columns[20].Visibility = Visibility.Collapsed;
            container_pages.Columns[21].Visibility = Visibility.Collapsed;
            container_pages.Columns[22].Header = "Имя сотрудника";
            container_pages.Columns[23].Visibility = Visibility.Collapsed;
            container_pages.Columns[24].Visibility = Visibility.Collapsed;
            container_pages.Columns[25].Visibility = Visibility.Collapsed;
            container_pages.Columns[26].Visibility = Visibility.Collapsed;
            container_pages.Columns[27].Visibility = Visibility.Collapsed;
            container_pages.Columns[28].Header = "Статус заказа";
            container_pages.Columns[29].Visibility = Visibility.Collapsed;
        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write_pass.Text = "";
            zakaz_num.Text = "";
            totalcost.Text = "";
            guitar_cbx.SelectedItem = null;
            client_cbx.SelectedItem = null;
            employee_cbx.SelectedItem = null;
            status_cbx.SelectedItem = null;

            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow)
                {
                 
                    write_pass.Text = selectedRow["AmountGuitars"].ToString();

                    datas.Text = selectedRow["DateOfMadeOrder"].ToString();

                    if (selectedRow["TotalPrice"] != DBNull.Value)
                    {
                        int totalPriceInt = Convert.ToInt32(selectedRow["TotalPrice"]);
                        string totalPriceString = totalPriceInt.ToString();
                        totalcost.Text = totalPriceString;
                    }

                    //totalcost.Text = selectedRow["TotalPrice"].ToString();

                    zakaz_num.Text = selectedRow["NumberOfOrder"].ToString();

         

                    int guiid = Convert.ToInt32(selectedRow["Guitar_ID"]);
                    int cliid = Convert.ToInt32(selectedRow["Client_ID"]);
                    int empid = Convert.ToInt32(selectedRow["Employee_ID"]);
                    int ordid = Convert.ToInt32(selectedRow["OrderStatus_ID"]);
             

                    foreach (DataRowView item in guitar_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_Guitar"]) == guiid)
                        {
                            guitar_cbx.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (DataRowView item in client_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_Client"]) == cliid)
                        {
                            client_cbx.SelectedItem = item;
                            break;
                        }
                    }


                    foreach (DataRowView item in employee_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_Employees"]) == empid)
                        {
                            employee_cbx.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (DataRowView item in status_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_OrderStatus"]) == ordid)
                        {
                            status_cbx.SelectedItem = item;
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
            container_pages.Columns[2].Visibility = Visibility.Collapsed;
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Количество гитар";
            container_pages.Columns[16].Header = "Название гитары";
            container_pages.Columns[17].Header = "Имя клиента";
            container_pages.Columns[4].Header = "Дата заказа";
            container_pages.Columns[5].Header = "Стоимость всего заказа";
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Header = "Номер заказа";
            container_pages.Columns[8].Visibility = Visibility.Collapsed;
            container_pages.Columns[9].Visibility = Visibility.Collapsed;
            container_pages.Columns[10].Visibility = Visibility.Collapsed;
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Visibility = Visibility.Collapsed;
            container_pages.Columns[15].Visibility = Visibility.Collapsed;
            container_pages.Columns[18].Visibility = Visibility.Collapsed;
            container_pages.Columns[19].Visibility = Visibility.Collapsed;
            container_pages.Columns[20].Visibility = Visibility.Collapsed;
            container_pages.Columns[21].Visibility = Visibility.Collapsed;
            container_pages.Columns[22].Header = "Имя сотрудника";
            container_pages.Columns[23].Visibility = Visibility.Collapsed;
            container_pages.Columns[24].Visibility = Visibility.Collapsed;
            container_pages.Columns[25].Visibility = Visibility.Collapsed;
            container_pages.Columns[26].Visibility = Visibility.Collapsed;
            container_pages.Columns[27].Visibility = Visibility.Collapsed;
            container_pages.Columns[28].Header = "Статус заказа";
            container_pages.Columns[29].Visibility = Visibility.Collapsed;

        }

        private void write_pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
