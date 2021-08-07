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
using WpfApp.ApiHelpers;
using WpfApp.Models;

namespace WpfApp.Views.TripViews
{
    /// <summary>
    /// Interaction logic for CreateCruise.xaml
    /// </summary>
    public partial class CreateTrip : Window
    {
        private ITripCaller tripCaller;
        public CreateTrip()
        {
            InitializeComponent();
            tripCaller = new TripCaller();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime tempDepartureDate = DateTime.Parse(departureDate.Text);
                DateTime tempArrivalDate = DateTime.Parse(arrivalDate.Text);
                Trip trip = new Trip(name.Text, description.Text, departurePlace.Text, arrivalPlace.Text, DateTime.SpecifyKind(tempDepartureDate, DateTimeKind.Utc), DateTime.SpecifyKind(tempArrivalDate, DateTimeKind.Utc));
                trip.UserId = "b8654dca-e5da-4af0-bf3a-a92534cacd85";
                var result = tripCaller.CreateTrip(trip);
                if (result.IsSuccessful)
                {
                    Window window = new TripMenu();
                    window.Show();
                    Close();
                } else
                {
                   errorBox.Text = "Please insert correct data!";
                }

            }
            catch (Exception)
            {
                errorBox.Text = "Please insert correct data!";
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window window = new TripMenu();
            window.Show();
            Close();
        }
    }
}
