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
using UP_01._01.Laba_5.up_laba_5DataSetTableAdapters;

namespace UP_01._01.Laba_5
{
    /// <summary>
    /// Логика взаимодействия для SotrydnikWindow.xaml
    /// </summary>
    public partial class SotrydnikWindow : Window
    {
      
        public SotrydnikWindow()
        {
            InitializeComponent();


            MinHeight = 650;
            MinWidth = 820;
        }

        private void clients_show_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Clients();
        }

        private void zakazi_show_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Zakazi();
        }

        private void guitars_show_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Guitars();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }

        private void chechki_show_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Checks();
        }
    }
}
