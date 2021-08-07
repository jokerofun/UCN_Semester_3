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

namespace WpfApp.Views.UserTicketViews
{
    /// <summary>
    /// Interaction logic for UpdateUserTicket.xaml
    /// </summary>
    public partial class UpdateUserTicket : Window
    {
        private IUserTicketCaller userTicketCaller;
        private int id;
        private bool active;
        private string userId;
        public UpdateUserTicket(UserTicket userTicket)
        {
            InitializeComponent();
            InitializeData(userTicket);
            userTicketCaller = new UserTicketCaller();
        }
        private void InitializeData(UserTicket userTicket)
        {
            id = userTicket.Id;
            active = userTicket.Active;
            userId = userTicket.UserId;
            firstName.Text = userTicket.FirstName;
            lastName.Text = userTicket.LastName;
            ticketId.Text = userTicket.TicketId.ToString();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window window = new UserTicketMenu();
            window.Show();
            Close();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                UserTicket userTicket = new UserTicket(id, firstName.Text, lastName.Text, Int32.Parse(ticketId.Text), active, userId);
                var result = userTicketCaller.UpdateUserTicket(userTicket);
                if (result.IsSuccessful)
                {
                    Window window = new UserTicketMenu();
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
    }
}
