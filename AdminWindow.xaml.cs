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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
  

        public AdminWindow()
        {
            InitializeComponent();

            MinHeight = 650;
            MinWidth = 820;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }

        private void RoleUser_Click(object sender, RoutedEventArgs e)
        {
            container_pages.Content = new Roles(); 
        }

        private void userdata_Click(object sender, RoutedEventArgs e)
        {
           
            container_pages.Content = new UserData();
        }

        private void employeeshow_Click(object sender, RoutedEventArgs e)
        {
            
            container_pages.Content = new Employees();
        }

     
        private void positionsshow_Click_1(object sender, RoutedEventArgs e)
        {
            
            container_pages.Content = new Positions();
        }

        private void backup_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                QueriesTableAdapter back = new QueriesTableAdapter();
                back.Backup_Guitars();
                MessageBox.Show("Бэкап был успешно создан по пути: 'C:\\Users\\Public\\Documents\\MS'");
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при создании бэкапа!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminWindow2 admin = new AdminWindow2();
            admin.ShowDialog();
        }
    }
}
