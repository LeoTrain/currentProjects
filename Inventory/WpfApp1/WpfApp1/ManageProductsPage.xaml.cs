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
    /// Interaction logic for ManageProductsPage.xaml
    /// </summary>
    public partial class ManageProductsPage : Page
    {
        private DataBaseManager _dbManager {  get; set; }
        private List<Product> _products {  get; set; }
        public ManageProductsPage()
        {
            InitializeComponent();
            this._dbManager = new DataBaseManager();
            this._products = this._dbManager.GetProducts();
            ProductsDataGrid.ItemsSource = this._products;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void ModifyProductBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work in progress..");
        }
    }
}
