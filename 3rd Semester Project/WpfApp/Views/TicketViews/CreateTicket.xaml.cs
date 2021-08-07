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
    /// Interaction logic for CreateTicket.xaml
    /// </summary>
    public partial class CreateTicket : Window
    {
        private ITicketCaller ticketCaller;
        private int cruiseId;
        public CreateTicket(int cruiseid)
        {
            InitializeComponent();
            ticketCaller = new TicketCaller();
            cruiseId = cruiseid;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket ticket = new Ticket(name.Text, Decimal.Parse(price.Text), int.Parse(maxTickets.Text), cruiseId);
                var result = ticketCaller.CreateTicket(ticket);
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
        private void Back(object sender, RoutedEventArgs e)
        {
            Window window = new TicketMenu(cruiseId);
            window.Show();
            Close();
        }
    }
}
