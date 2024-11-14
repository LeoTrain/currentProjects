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
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBaseManager dbManager = new DataBaseManager();

            string name = ProductNameTB.Text;
            string definition = ProductDefinitionTB.Text;
            double price = double.Parse(ProductPriceTB.Text);
            int amount = int.Parse(ProductAmountTB.Text);

            dbManager.AddProduct(name, definition, price, amount);
        }

        private void CancelProductBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }
    }
}
