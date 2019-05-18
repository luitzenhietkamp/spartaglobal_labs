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

namespace hw_104_WPF_Northwind_Entity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<StackPanel> views;

        public MainWindow()
        {
            InitializeComponent();

            // Custom Initialization
            Initialize();

            // Initialise employees
            InitialiseEmployees();

            // Initialise suppliers
            InitialiseSuppliers();

            // Initialise products
            InitialiseProducts();

            // Initialise customers
            InitialiseCustomers();
        }

        void Initialize()
        {
            views = new List<StackPanel> {
                EmployeesPanel,
                SuppliersPanel,
                ProductsPanel,
                CustomersPanel
            };
            views.ForEach(panel => panel.Visibility = Visibility.Collapsed);
            views[0].Visibility = Visibility.Visible;
        }

        void InitialiseEmployees()
        {
            using (var db = new NorthwindEntities())
            {
                var employees = db.Employees.ToList();
                DGEmployees.DataContext = employees;
            }
        }

        void InitialiseSuppliers()
        {
            using (var db = new NorthwindEntities())
            {
                var suppliers = db.Suppliers.ToList();
                DGSuppliers.DataContext = suppliers;
            }
        }

        void InitialiseProducts()
        {
            using (var db = new NorthwindEntities())
            {
                var products = db.Products.ToList();
                DGProducts.DataContext = products;
            }
        }

        void InitialiseCustomers()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.ToList();
                DGCustomers.DataContext = customers;
            }
        }

        private void SwitchView_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = (Button)sender;

            views.ForEach(panel => panel.Visibility = Visibility.Collapsed);
            switch (clickedButton.Name)
            {
                case "SwitchToEmployees":
                    views[0].Visibility = Visibility.Visible;
                    break;
                case "SwitchToSuppliers":
                    views[1].Visibility = Visibility.Visible;
                    break;
                case "SwitchToProducts":
                    views[2].Visibility = Visibility.Visible;
                    break;
                case "SwitchToCustomers":
                    views[3].Visibility = Visibility.Visible;
                    break;
            }
            using (var db = new NorthwindEntities())
            {
                var customer = new Customers();

                var order = (from o in db.Orders
                             select o)
                    .Where(o => o.CustomerID == customer.CustomerID)
                    .Where(o=>true);
            }
        }
    }
}
