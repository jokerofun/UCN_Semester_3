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
    /// Interaction logic for UpdateCruise.xaml
    /// </summary>
    public partial class UpdateTrip : Window
    {
        private ITripCaller tripCaller;
        private int id;
        private string userId;
        public UpdateTrip(Trip trip)
        {
            InitializeComponent();
            InitializeData(trip);
            tripCaller = new TripCaller();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime tempDepartureDate = DateTime.Parse(departureDate.Text);
                DateTime tempArrivalDate = DateTime.Parse(arrivalDate.Text);
                Trip trip = new Trip(id, name.Text, description.Text, departurePlace.Text, arrivalPlace.Text, DateTime.SpecifyKind(tempDepartureDate, DateTimeKind.Utc), DateTime.SpecifyKind(tempArrivalDate, DateTimeKind.Utc), userId);
                var result = tripCaller.UpdateTrip(trip);
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

        private void InitializeData(Trip trip)
        {
            id = trip.ID;
            userId = trip.UserId;

            name.Text = trip.Name;
            description.Text = trip.Description;
            departurePlace.Text = trip.DeparturePlace;
            arrivalPlace.Text = trip.ArrivalPlace;
            departureDate.Text = trip.DepartureDate.ToString();
            arrivalDate.Text = trip.ArrivalDate.ToString();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window window = new TripMenu();
            window.Show();
            Close();
        }
    }
}
