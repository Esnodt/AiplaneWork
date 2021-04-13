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
    /// Логика взаимодействия для EditPAge.xaml
    /// </summary>
    public partial class EditPAge : Page
    {
        private Airplane editmain;
        public EditPAge()
        
        {
            InitializeComponent();
        }


        public EditPAge(Airplane editmain)
        {
            this.editmain = editmain;

            InitializeComponent();
            tbDeparturePoint.Text = editmain.DeparturePoint;
            tbDestination.Text = editmain.Destination;
            tbDepartureTime.SelectedDate = editmain.DepartureTime;
            tbTicketPrice.Text = Convert.ToString(editmain.TicketPrice);

            tbFullName.Text = editmain.Pilot.FullName;
            tbWorkExperience.Text = editmain.Pilot.WorkExperience;
            tbEducation.Text = editmain.Pilot.Education;

        }

       


        private void editbutton_Click(object sender, RoutedEventArgs e)
        {
            Airplane Save = dbclass.db.Airplane.FirstOrDefault(item => item.ID == editmain.ID);

            Save.DeparturePoint = tbDeparturePoint.Text;
            Save.Destination = tbDestination.Text;
            Save.DepartureTime = tbDepartureTime.SelectedDate;
            Save.TicketPrice = Convert.ToInt32(tbTicketPrice.Text);

            Save.Pilot.FullName = tbFullName.Text;
            Save.Pilot.WorkExperience = tbWorkExperience.Text;
            Save.Pilot.Education = tbEducation.Text;


            dbclass.db.SaveChanges();

            MessageBox.Show("Вы изменили данные", "Уведомление");


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
