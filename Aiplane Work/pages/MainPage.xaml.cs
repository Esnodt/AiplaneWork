using Aiplane_Work.contextclass;
using Aiplane_Work.sql;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
using System.Xml;
using System.Xml.Serialization;

namespace Aiplane_Work.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GridMainTable.ItemsSource = dbclass.db.Airplane.ToList();
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Airplane deleterow = (Airplane)GridMainTable.SelectedItem;
            if (MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (deleterow != null)
                {
                    dbclass.db.Airplane.Remove(deleterow);
                    dbclass.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы удалили данные", "Увдомление");
                }

                else
                {
                    MessageBox.Show("Вы не выбрали элемент для удаления", "Увдомление");

                }

            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Airplane editrow = (Airplane)GridMainTable.SelectedItem;
            if (editrow != null)
            {
                NavigationService.Navigate(new EditPAge(editrow));
            }
        }

        private void btnxml_Click(object sender, RoutedEventArgs e)
        {
            List<Pilot> pilots = new List<Pilot>(dbclass.db.Pilot.ToList());
            string path = @"C:\Users\Esnodt\Documents\Data.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach(var item in pilots)
                {
                    writer.WriteLine(item.ID);
                    writer.WriteLine(item.FullName);
                    writer.WriteLine(item.WorkExperience);
                    writer.WriteLine(item.Education);
                }
            }
        }

        private void GridMainTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}