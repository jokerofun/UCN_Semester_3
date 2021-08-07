using RestSharp;
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
using WpfApp.Views.TripViews;

namespace WpfApp.Views.TicketViews
{
    /// <summary>
    /// Interaction logic for CruiseMenu.xaml
    /// </summary>
    public partial class TicketMenu : Window
    {
        private ITicketCaller ticketCaller;

        private int tripId;

        public TicketMenu(int tripId)
        {
            InitializeComponent();
            ticketCaller = new TicketCaller();
            GetData(tripId);
            this.tripId = tripId;
        }

        private void GetData(int tripId)
        {
            var result = ticketCaller.GetTicketsByTripId(tripId);
            foreach (var item in result)
            {
                dg.Items.Add(new Ticket { Id = item.Id, TicketName = item.TicketName, Price = item.Price, MaxTickets = item.MaxTickets });
            }
        }

        private void CreateTicket(object sender, RoutedEventArgs e)
        {
            Window createTicket = new CreateTicket(tripId);
            createTicket.Show();
            Close();
        }

        private void UpdateTicket(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                Window updateTicket = new UpdateTicket((Ticket)dg.SelectedItem, tripId);
                updateTicket.Show();
                Close();
            }
        }
        private void DeleteMessageBox(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                // Configure the message box to be displayed
                string messageBoxText = "Do you want to delete the selected ticket?";
                string caption = "Deleting ticket";
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;

                // Display message box
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                // Process message box results
                switch (result)
                {
                    case MessageBoxResult.OK:
                        var response = ticketCaller.DeleteTicket((Ticket)dg.SelectedItem);
                        if (response.IsSuccessful)
                        {
                            dg.Items.Clear();
                            GetData(tripId);
                        }
                        else
                        {
                            MessageBox.Show("There was an error when deleting the selected ticket.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case MessageBoxResult.Cancel:

                        break;
                }

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

