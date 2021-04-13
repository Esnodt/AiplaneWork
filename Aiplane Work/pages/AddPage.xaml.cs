using Aiplane_Work.contextclass;
using Aiplane_Work.sql;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aiplane_Work.pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            Airplane addAirplane = new Airplane();
            Pilot addPilot = new Pilot();

            addAirplane.IDPilot = addPilot.ID;

            addAirplane.DeparturePoint = tbDeparturePoint.Text;
            addAirplane.Destination = tbDestination.Text;
            addAirplane.DepartureTime = (DateTime)tbDepartureTime.SelectedDate;
            addAirplane.TicketPrice = Convert.ToInt32(tbTicketPrice.Text);


            addPilot.FullName = tbFullName.Text;
            addPilot.WorkExperience = tbWorkExperience.Text;
            addPilot.Education = tbEducation.Text;


            dbclass.db.Airplane.Add(addAirplane);
            dbclass.db.Pilot.Add(addPilot);

            dbclass.db.SaveChanges();
            MessageBox.Show("Вы добавили данные", "Уведомление");
            




        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            tbDeparturePoint.Text = "";
            tbDestination.Text = "";
            tbDepartureTime.Text = null;
            tbTicketPrice.Text = "";

            tbFullName.Text = "";
            tbWorkExperience.Text = "";
            tbEducation.Text = "";
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
