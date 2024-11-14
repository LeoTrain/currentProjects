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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ManageCustomerOptions.xaml
    /// </summary>
    public partial class ManageCustomerOptions : Window
    {
        string CustomerID { get; set; }
        public ManageCustomerOptions(string id)
        {
            InitializeComponent();
            CustomerID = id;
        }

        private void NewNameBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBaseManager dataBaseManager = new DataBaseManager();
            AddNewNameWindow addNewNameWindow = new AddNewNameWindow();
            bool? result = addNewNameWindow.ShowDialog();

            if (result == true)
            {
                dataBaseManager.ModifyName(CustomerID, addNewNameWindow.ResponseText);
            }
        }

        private void DeletUserBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBaseManager dbmanager = new DataBaseManager();
            AreYouShureAboutThat aysat = new AreYouShureAboutThat();
            bool? response = aysat.ShowDialog();
            if (response == true)
            {
                dbmanager.DeleteCustomer(CustomerID);
            }
        }

        private void NewMailBtn_Click(object sender, RoutedEventArgs e)
        {
            DataBaseManager dataBaseManager = new DataBaseManager();
            AddNewMailWindow addNewMailWindow = new AddNewMailWindow();
            bool? result = addNewMailWindow.ShowDialog();

            if (result == true)
            {
                dataBaseManager.ModifyMail(CustomerID, addNewMailWindow.ResponseText);
            }
        }
    }
}
