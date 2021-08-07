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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private IAccountCaller accountCaller;
        public Register()
        {
            InitializeComponent();
            accountCaller = new AccountCaller();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void PerformRegister(object sender, RoutedEventArgs e)
        {
            if (!Email.Text.Equals("") && Password.Password.Equals(ConfirmPassword.Password))
            {
                try
                {
                    RegisterAccountModel model = new RegisterAccountModel(Email.Text, Password.Password, ConfirmPassword.Password, (bool)IsBusiness.IsChecked);
                    var result = accountCaller.Register(model);
                    if (result.IsSuccessful)
                    {
                        Window window = new MainMenu();
                        window.Show();
                        Close();
                    }
                    else
                    {
                        ErrorBox.Text = "Email or password wrong!";
                    }
                }
                catch (Exception)
                {
                    ErrorBox.Text = "There was a problem in creating your account!";
                }

            }
            else
            {
                ErrorBox.Text = "Please fill all fields!";
            }
        }
    }
}
