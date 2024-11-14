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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            DataBaseManager dbManager = new DataBaseManager();
            string userName = UsernameLabel.Text;
            string password = PasswordLabel.Text;
            if (dbManager.CustomerNameExists(userName))
            { 
                if (dbManager.NameAndPasswordCorrespond(userName, password))
                    NavigationService.Navigate(new Home());
                else
                    MessageBox.Show($"Password and Username doe not correspond.");
            }
            else
                MessageBox.Show($"User {userName} does not exist.");
        }
    }
}
