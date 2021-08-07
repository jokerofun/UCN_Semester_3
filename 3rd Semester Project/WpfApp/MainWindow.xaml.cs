using System;
using System.Windows;
using WpfApp.ApiHelpers;
using WpfApp.Models;
using WpfApp.Views.TripViews;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAccountCaller accountCaller;
        public MainWindow()
        {
            InitializeComponent();
            accountCaller = new AccountCaller();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            Window window = new Register();
            window.Show();
            Close();
        }

        private void PerformLogin(object sender, RoutedEventArgs e)
        {
            if (!Email.Text.Equals("") && !Password.Password.Equals(""))
            {
                try
                {
                    LoginViewModel model = new LoginViewModel(Email.Text, Password.Password);
                    var result = accountCaller.Login(model);
                    if (result.IsSuccessful)
                    {
                        Window window = new MainMenu();
                        window.Show();
                        Close();
                    }
                    else
                    {
                        ErrorBox.Text = "Incorrect data input!";
                    }
                }
                catch (Exception)
                {
                    ErrorBox.Text = "There was a problem in logging to your account!";
                }

            }
            else
            {
                ErrorBox.Text = "Please fill all fields!";
            }
        }

    }
}
