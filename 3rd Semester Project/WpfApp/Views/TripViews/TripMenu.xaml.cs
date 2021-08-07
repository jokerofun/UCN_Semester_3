using RestSharp;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.ApiHelpers;
using WpfApp.Models;
using WpfApp.Views.TicketViews;

namespace WpfApp.Views.TripViews
{
    /// <summary>
    /// Interaction logic for CruiseMenu.xaml
    /// </summary>
    public partial class TripMenu : Window
    {
        private ITripCaller tripCaller;
        public TripMenu()
        {
            InitializeComponent();
            tripCaller = new TripCaller();
            GetMatchedData();
        }

        private void GetMatchedData()
        {

            Trip trip = new Trip();
            trip.Name = searchName.Text;
            trip.DeparturePlace = searchDeparturePlace.Text;
            trip.ArrivalPlace = searchArrivalPlace.Text;
            if (searchDepartureDate.SelectedDate != null)
            {
                DateTime temp = (DateTime)searchDepartureDate.SelectedDate;
                trip.DepartureDate = DateTime.SpecifyKind(temp, DateTimeKind.Utc);

            }
            if (searchArrivalDate.SelectedDate != null)
            {
                DateTime temp = (DateTime)searchArrivalDate.SelectedDate;
                trip.ArrivalDate = DateTime.SpecifyKind(temp, DateTimeKind.Utc);
            }
            var result = tripCaller.GetMatchingTripsUpToDate(trip);
            dg.Items.Clear();
            foreach (var item in result)
            {
                dg.Items.Add(new Trip { ID = item.ID, Name = item.Name, Description = item.Description, DeparturePlace = item.DeparturePlace, ArrivalPlace = item.ArrivalPlace, DepartureDate = item.DepartureDate, ArrivalDate = item.ArrivalDate, UserId = item.UserId });
            }

        }

        private void CreateTrip(object sender, RoutedEventArgs e)
        {
            Window window = new CreateTrip();
            window.Show();
            Close();
        }

        private void UpdateTrip(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                Trip selectedItem = (Trip)dg.SelectedItem;
                Window window = new UpdateTrip(selectedItem);
                window.Show();
                Close();
            }
        }

        private void DeleteMessageBox(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                // Configure the message box to be displayed
                string messageBoxText = "Do you want to delete the selected trip?";
                string caption = "Deleting trip";
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;

                // Display message box
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                // Process message box results
                switch (result)
                {
                    case MessageBoxResult.OK:
                        var response = tripCaller.DeleteTrip((Trip)dg.SelectedItem);
                        if (response.IsSuccessful)
                        {
                            dg.Items.Clear();
                            GetMatchedData();
                        }
                        else
                        {
                            MessageBox.Show("There was an error when deleting the selected trip. The reason may be because it contains tickets.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case MessageBoxResult.Cancel:

                        break;
                }

            }
        }

        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                Trip temp = (Trip)dg.SelectedItem;
                Window ticketMenu = new TicketMenu(temp.ID);
                ticketMenu.Show();
                Close();
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Trip temp = (Trip)row.Item;
            Window ticketMenu = new TicketMenu(temp.ID);
            ticketMenu.Show();
            Close();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window window = new MainMenu();
            window.Show();
            Close();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            GetMatchedData();
        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            GetMatchedData();
        }

    }
}
