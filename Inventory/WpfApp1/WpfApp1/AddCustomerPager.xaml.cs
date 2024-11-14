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
    /// Interaction logic for AddCustomerPager.xaml
    /// </summary>
    public partial class AddCustomerPager : Page
    {
        public AddCustomerPager()
        {
            InitializeComponent();
        }

        private void RegisterCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = AddCustomerUsernameTB.Text;
            string email = AddCustomerEmailTB.Text;
            string passwordHash = AddCustomerPasswordTB.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passwordHash))
                throw new ArgumentException("Name, Email and Password must all be valid strings.");

            DataBaseManager dbManager = new DataBaseManager();

            bool succesfullyAdded = dbManager.AddCustomer(name, email, passwordHash);
            if (succesfullyAdded)
            {
                MessageBox.Show($"User {name} has been added succesfully!");
            }
            else
            {
                MessageBox.Show("There was an error adding the User.");
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }
    }
}
