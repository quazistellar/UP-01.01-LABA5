using System;
using System.Collections.Generic;
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
using UP_01._01.Laba_5.Model;
using UP_01._01.Laba_5.up_laba_5DataSetTableAdapters;

namespace UP_01._01.Laba_5
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow2.xaml
    /// </summary>
    public partial class AdminWindow2 : Window
    {
    
        public AdminWindow2()
        {
            InitializeComponent();

            MinHeight = 650;
            MinWidth = 820;
        }

        private void VidGuitar_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new VidGuitar();
        }

        private void GuitarForm_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new GuitarForm();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }

        private void zvuk_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new SoundConfig();
        }

        private void country_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Country();
        }

        private void stringstbl_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new StringsAm();
        }

        private void clients_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Clients();
        }

        private void guitars_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Guitars();
        }

        private void zakazi_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Zakazi();
        }

        private void statuszakaza_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new StatusZakaza();
        }

     
    }
}
