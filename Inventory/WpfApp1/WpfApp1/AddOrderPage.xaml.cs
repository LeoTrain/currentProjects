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
    /// Interaction logic for AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private DataBaseManager _dbManager {  get; set; }
        private List<Product> _products {  get; set; }
        private List<Product> _orderProducts { get; set; }
        public AddOrderPage()
        {
            InitializeComponent();
            this._dbManager = new DataBaseManager();
            this._products = this._dbManager.GetProducts();
            this._orderProducts = new List<Product>();
            this.LoadProductList();
        }

        private void LoadProductList()
        {
            ProductComboBox.Items.Clear();
            foreach (Product product in this._products)
                ProductComboBox.Items.Add(product.Name);
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            int nbrOfItems = (int)NumberOfItemBox.Value;
            foreach (Product product in this._products)
            {
                if (product.Name == ProductComboBox.SelectedItem.ToString())
                {
                    double completePrice = product.Price * nbrOfItems;
                    this._orderProducts.Add(new Product
                    {
                        ProductID = product.ProductID,
                        Name = product.Name,
                        Definition = product.Definition,
                        Price = completePrice,
                        Amount = nbrOfItems,
                    });
                }
            }
            OrderDataGrid.ItemsSource = this._orderProducts;
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }
    }
}
