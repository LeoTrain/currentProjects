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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void NewCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCustomerPager());
        }

        private void ManagerCustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageCustomerPage());
        }

        private void NewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderPage());
        }

        private void NewProductBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }

        private void ManageProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageProductsPage());
        }
    }
}
