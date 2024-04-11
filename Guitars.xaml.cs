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
    /// Логика взаимодействия для Guitars.xaml
    /// </summary>
    public partial class Guitars : Page
    {
        GuitarsTableAdapter guitars = new GuitarsTableAdapter();
        VidGuitarTableAdapter vid = new VidGuitarTableAdapter();
        GuitarFormTableAdapter form = new GuitarFormTableAdapter();
        SoundConfigurationTableAdapter sound = new SoundConfigurationTableAdapter();
        CountryOfMadeTableAdapter cntr = new CountryOfMadeTableAdapter();
        AmountStringsTableAdapter strings = new AmountStringsTableAdapter();

        public Guitars()
        {
            InitializeComponent();



            container_pages.ItemsSource = guitars.GetFullData();

            MinHeight = 550;
            MinWidth = 800;

            vid_cbx.ItemsSource = vid.GetData();
            vid_cbx.DisplayMemberPath = "NameOfVidGuitar";


            form_cbx.ItemsSource = form.GetData();
            form_cbx.DisplayMemberPath = "NameOfGuitarForm";



            posit_bx.ItemsSource = sound.GetData();
            posit_bx.DisplayMemberPath = "NameOfConfiguration";


            country_cbx.ItemsSource = cntr.GetData();
            country_cbx.DisplayMemberPath = "NameOfCountry";

            strings_cbx.ItemsSource = strings.GetData();
            strings_cbx.DisplayMemberPath = "AmountOfStrings";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            container_pages.Columns[0].Visibility = Visibility.Collapsed;
            container_pages.Columns[1].Header = "Название гитары";
            container_pages.Columns[2].Header = "Цена гитары";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Header = "Вид гитары";
            container_pages.Columns[9].Header = "Форма гитары";
            container_pages.Columns[10].Header = "Конфигурация звукоснимателей";
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Header = "Страна производства";
            container_pages.Columns[15].Header = "Количество струн";
            container_pages.Columns[16].Visibility = Visibility.Collapsed;
            container_pages.Columns[17].Visibility = Visibility.Collapsed;

        }

        private void container_pages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            write_log.Text = "";
            write_pass.Text = "";
            vid_cbx.SelectedItem = null;
            form_cbx.SelectedItem = null;
            posit_bx.SelectedItem = null;
            country_cbx.SelectedItem = null;
            strings_cbx.SelectedItem = null;

            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow)
                {
                    write_log.Text = selectedRow["NameGuitar"].ToString();

                    if (selectedRow["PriceGuitar"] != DBNull.Value)
                    {
                        int priceInt = Convert.ToInt32(selectedRow["PriceGuitar"]);
                        string priceString = priceInt.ToString();
                        write_pass.Text = priceString;
                    }
                    //write_pass.Text = selectedRow["PriceGuitar"].ToString();
                
                    int vidid = Convert.ToInt32(selectedRow["VidGuitar_ID"]);
                    int formid = Convert.ToInt32(selectedRow["GuitarForm_ID"]);
                    int soundid = Convert.ToInt32(selectedRow["SoundConfiguration_ID"]);
                    int cntryid = Convert.ToInt32(selectedRow["CountryOfMade_ID"]);
                    int stringsid = Convert.ToInt32(selectedRow["AmountStrings_ID"]);

                    foreach (DataRowView item in vid_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_VidGuitar"]) == vidid)
                        {
                            vid_cbx.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (DataRowView item in form_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_GuitarForm"]) == formid)
                        {
                            form_cbx.SelectedItem = item;
                            break;
                        }
                    }


                    foreach (DataRowView item in posit_bx.Items)
                    {
                        if (Convert.ToInt32(item["ID_SoundConfiguration"]) == soundid)
                        {
                            posit_bx.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (DataRowView item in country_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_CountryOfMade"]) == cntryid)
                        {
                            country_cbx.SelectedItem = item;
                            break;
                        }
                    }

                    foreach (DataRowView item in strings_cbx.Items)
                    {
                        if (Convert.ToInt32(item["ID_AmountStrings"]) == stringsid)
                        {
                            strings_cbx.SelectedItem = item;
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
            container_pages.Columns[1].Header = "Название гитары";
            container_pages.Columns[2].Header = "Цена гитары";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Header = "Вид гитары";
            container_pages.Columns[9].Header = "Форма гитары";
            container_pages.Columns[10].Header = "Конфигурация звукоснимателей";
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Header = "Страна производства";
            container_pages.Columns[15].Header = "Количество струн";
            container_pages.Columns[16].Visibility = Visibility.Collapsed;
            container_pages.Columns[17].Visibility = Visibility.Collapsed;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (write_pass.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в цену гитары!");
                return;
            }

        

            if (string.IsNullOrWhiteSpace(write_log.Text.Trim()) || string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || (write_pass.Text.Trim() == "" && write_log.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }

            if (write_log.Text.Length < 3)
            {

                MessageBox.Show("Длина названия должна быть хотя бы 2 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }


            try
            {
                if (vid_cbx.SelectedItem != null && form_cbx.SelectedItem != null && posit_bx.SelectedItem != null
                    && country_cbx.SelectedItem != null && strings_cbx.SelectedItem != null
                    && vid_cbx.SelectedItem is DataRowView selectedVid && form_cbx.SelectedItem is DataRowView selectedForm
                    && posit_bx.SelectedItem is DataRowView selectedSound && country_cbx.SelectedItem is DataRowView selectedCountry
                    && strings_cbx.SelectedItem is DataRowView selectedStrings)
                {
                    int vidid = Convert.ToInt32(selectedVid["ID_VidGuitar"]);
                    int formid = Convert.ToInt32(selectedForm["ID_GuitarForm"]);
                    int soundid = Convert.ToInt32(selectedSound["ID_SoundConfiguration"]);
                    int cntryid = Convert.ToInt32(selectedCountry["ID_CountryOfMade"]);
                    int stringsid = Convert.ToInt32(selectedStrings["ID_AmountStrings"]);

                    guitars.InsertQueryGuitar(write_log.Text.Trim(), Convert.ToDecimal(write_pass.Text), vidid, formid, soundid, cntryid, stringsid);
                    container_pages.ItemsSource = guitars.GetFullData();
                }
                else
                {
                    if (vid_cbx.SelectedItem == null || form_cbx.SelectedItem == null || posit_bx.SelectedItem == null
                        || country_cbx.SelectedItem == null || strings_cbx.SelectedItem == null)
                    {
                        MessageBox.Show("Вы не выбрали запись!");
                    }
                    else if (write_log.Text.Trim() == "")
                    {
                        MessageBox.Show("Название гитары не было внесено в поле");
                    }
                    else if (write_pass.Text.Contains("."))
                    {
                        MessageBox.Show("Цена введена через точку, надо через запятую");
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
            container_pages.Columns[1].Header = "Название гитары";
            container_pages.Columns[2].Header = "Цена гитары";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Header = "Вид гитары";
            container_pages.Columns[9].Header = "Форма гитары";
            container_pages.Columns[10].Header = "Конфигурация звукоснимателей";
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Header = "Страна производства";
            container_pages.Columns[15].Header = "Количество струн";
            container_pages.Columns[16].Visibility = Visibility.Collapsed;
            container_pages.Columns[17].Visibility = Visibility.Collapsed;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(write_log.Text.Trim()) || string.IsNullOrWhiteSpace(write_pass.Text.Trim()) || (write_pass.Text.Trim() == "" && write_log.Text.Trim() == ""))
            {
                MessageBox.Show("Данные не могут быть пустыми");
                return;
            }

            if (write_pass.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Нельзя вводить другие символы в цену гитары!");
                return;
            }


            if (write_log.Text.Length < 3)
            {

                MessageBox.Show("Длина названия должна быть хотя бы 2 символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }



            try
            {
                if (container_pages.SelectedItem is DataRowView selectedRow 
                    
                    && vid_cbx.SelectedItem is DataRowView selectedVid && form_cbx.SelectedItem is DataRowView selectedForm
                    && posit_bx.SelectedItem is DataRowView selectedSound && country_cbx.SelectedItem is DataRowView selectedCountry
                    && strings_cbx.SelectedItem is DataRowView selectedStrings)

                {
                    int selectedId = Convert.ToInt32(selectedRow["ID_Guitar"]);


                    int vidid = Convert.ToInt32(selectedVid["ID_VidGuitar"]);
                    int formid = Convert.ToInt32(selectedForm["ID_GuitarForm"]);
                    int soundid = Convert.ToInt32(selectedSound["ID_SoundConfiguration"]);
                    int cntryid = Convert.ToInt32(selectedCountry["ID_CountryOfMade"]);
                    int stringsid = Convert.ToInt32(selectedStrings["ID_AmountStrings"]);


                    guitars.UpdateQueryGuitar(write_log.Text.Trim(), Convert.ToDecimal(write_pass.Text), vidid, formid, soundid, cntryid, stringsid, selectedId);
                    container_pages.ItemsSource = guitars.GetFullData();
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
            container_pages.Columns[1].Header = "Название гитары";
            container_pages.Columns[2].Header = "Цена гитары";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Header = "Вид гитары";
            container_pages.Columns[9].Header = "Форма гитары";
            container_pages.Columns[10].Header = "Конфигурация звукоснимателей";
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Header = "Страна производства";
            container_pages.Columns[15].Header = "Количество струн";
            container_pages.Columns[16].Visibility = Visibility.Collapsed;
            container_pages.Columns[17].Visibility = Visibility.Collapsed;
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (container_pages.SelectedItem != null)
                {
                    object id = (container_pages.SelectedItem as DataRowView).Row[0];
                guitars.DeleteQueryGuitar(Convert.ToInt32(id));
                container_pages.ItemsSource = guitars.GetFullData();
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
            container_pages.Columns[1].Header = "Название гитары";
            container_pages.Columns[2].Header = "Цена гитары";
            container_pages.Columns[3].Visibility = Visibility.Collapsed;
            container_pages.Columns[4].Visibility = Visibility.Collapsed;
            container_pages.Columns[5].Visibility = Visibility.Collapsed;
            container_pages.Columns[6].Visibility = Visibility.Collapsed;
            container_pages.Columns[7].Visibility = Visibility.Collapsed;
            container_pages.Columns[8].Header = "Вид гитары";
            container_pages.Columns[9].Header = "Форма гитары";
            container_pages.Columns[10].Header = "Конфигурация звукоснимателей";
            container_pages.Columns[11].Visibility = Visibility.Collapsed;
            container_pages.Columns[12].Visibility = Visibility.Collapsed;
            container_pages.Columns[13].Visibility = Visibility.Collapsed;
            container_pages.Columns[14].Header = "Страна производства";
            container_pages.Columns[15].Header = "Количество струн";
            container_pages.Columns[16].Visibility = Visibility.Collapsed;
            container_pages.Columns[17].Visibility = Visibility.Collapsed;
        }

        private void write_log_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
          
        }

        private void write_pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           
        }
    }
}
