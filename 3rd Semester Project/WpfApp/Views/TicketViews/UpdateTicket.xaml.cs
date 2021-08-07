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

namespace WpfApp.Views.TicketViews
{
    /// <summary>
    /// Interaction logic for UpdateTicket.xaml
    /// </summary>
    public partial class UpdateTicket : Window
    {
        private ITicketCaller ticketCaller;
        private int ticketId;
        private int cruiseId;
        public UpdateTicket(Ticket ticket, int cruiseId)
        {
            InitializeComponent();
            InitializeData(ticket, cruiseId);
            ticketCaller = new TicketCaller();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket ticket = new Ticket(ticketId, ticketName.Text, Decimal.Parse(price.Text), int.Parse(maxTickets.Text), cruiseId);
                var result = ticketCaller.UpdateTicket(ticket);
                if (result.IsSuccessful)
                {
                    Window window = new TicketMenu(cruiseId);
                    window.Show();
                    Close();
                }
                else
                {
                    errorBox.Text = "Please insert correct data!";
                }

            }
            catch (Exception)
            {
                errorBox.Text = "Please insert correct data!";
            }
        }

        private void InitializeData(Ticket ticket, int cruiseid)
        {
            ticketId = ticket.Id;
            cruiseId = cruiseid;

            ticketName.Text = ticket.TicketName;
            price.Text = ticket.Price.ToString();
            maxTickets.Text = ticket.MaxTickets.ToString();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window window = new TicketMenu(cruiseId);
            window.Show();
            Close();
        }
    }
}
