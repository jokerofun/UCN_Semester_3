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
    /// Interaction logic for UserTicketMenu.xaml
    /// </summary>
    public partial class UserTicketMenu : Window
    {
        private IUserTicketCaller userTicketCaller;
        public UserTicketMenu()
        {
            InitializeComponent();
            userTicketCaller = new UserTicketCaller();
            GetData();
        }

        private void GetData()
        {
            var result = userTicketCaller.GetUserTickets();
            foreach (var item in result)
            {
                dg.Items.Add(new UserTicket {Id = item.Id, FirstName = item.FirstName, LastName = item.LastName, TicketId = item.TicketId, Active = item.Active, UserId = item.UserId  });
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Window window = new MainMenu();
            window.Show();
            Close();
        }

        private void UpdateUserTicket(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem != null)
            {
                UserTicket selectedItem = (UserTicket)dg.SelectedItem;
                Window window = new UpdateUserTicket(selectedItem);
                window.Show();
                Close();
            }
        }
    }
}
