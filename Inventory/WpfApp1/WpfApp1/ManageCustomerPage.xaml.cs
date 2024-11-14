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
    /// Interaction logic for ManageCustomerPage.xaml
    /// </summary>
    public partial class ManageCustomerPage : Page
    {
        public ManageCustomerPage()
        {
            InitializeComponent();
            this.LoadUsers();
        }

        private void LoadUsers()
        {
            DataBaseManager dbManager = new DataBaseManager();
            List<Customer> users = dbManager.GetCustomers();
            UsersDataGrid.ItemsSource = users;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void ModifyUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is Customer selectedCustomer)
            {
                ManageCustomerOptions options = new ManageCustomerOptions(selectedCustomer.CustomerID.ToString());
                options.ShowDialog();
                this.LoadUsers();
            }
            else
                MessageBox.Show("No User selected");

        }
    }
}
