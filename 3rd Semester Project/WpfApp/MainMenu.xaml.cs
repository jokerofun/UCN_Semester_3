using System.Windows;
using WpfApp.Views.TripViews;
using WpfApp.Views.UserTicketViews;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void TripMenu(object sender, RoutedEventArgs e)
        {
            Window window = new TripMenu();
            window.Show();
            Close();
        }
        private void UserTicketsMenu(object sender, RoutedEventArgs e)
        {
            Window window = new UserTicketMenu();
            window.Show();
            Close();
        }
    }
}
