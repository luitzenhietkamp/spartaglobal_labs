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

namespace lab_69_WPF_Entity_Crud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Customers> _customers;
        static List<Products> _products;
        static List<Employees> _employees;
        static List<Suppliers> _suppliers;
        static List<Orders> _orders;
        static List<Order_Details> _orderDetails;
        static List<TextBox> _fieldData;

        static Customers _customer;
        static Orders _order;
        static Order_Details _orderDetail;
        static Products _product;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            using (var db = new NorthwindEntities())
            {
                _customers = db.Customers.ToList();
                ListBox01.ItemsSource = _customers;
                ListBox01.DisplayMemberPath = "CompanyName";
            }

            SetCustomerFieldsDescription();
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            AddButton.IsEnabled = true;

            _fieldData = new List<TextBox>
            {
                Box1,
                Box2,
                Box3,
                Box4,
                Box5,
                Box6,
                Box7,
                Box8,
                Box9,
                Box10,
                Box11,
            };
        }

        private void ListCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                _customers = db.Customers.ToList();
                ListBox01.ItemsSource = _customers;
                ListBox01.DisplayMemberPath = "CompanyName";
            }
        }

        private void ListProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                _products = db.Products.ToList();
                ListBox01.ItemsSource = _products;
                ListBox01.DisplayMemberPath = "ProductName";
            }
        }

        private void ListSuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                _suppliers = db.Suppliers.ToList();
                ListBox01.ItemsSource = _suppliers;
                ListBox01.DisplayMemberPath = "CompanyName";
            }
        }

        private void ListEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                _employees = db.Employees.ToList();
                ListBox01.ItemsSource = _employees;
                ListBox01.DisplayMemberPath = "LastName";
            }
        }

        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox01.SelectedItem == null)
                return;

            SetCustomerFieldsDescription();
            SetCustomerFieldsData();

            ListBox02.ItemsSource = null;
            ListBox03.ItemsSource = null;
            ListBox04.ItemsSource = null;
            ListBox05.Items.Clear();

            _customer = ListBox01.SelectedItem as Customers;

            using (var db = new NorthwindEntities())
            {
                _orders = db.Orders.Where(o => o.CustomerID == _customer.CustomerID).ToList();
                ListBox02.ItemsSource = _orders;
                ListBox02.DisplayMemberPath = "OrderID";
            }

            SetCustomerFieldsData();
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
            AddButton.IsEnabled = false;
        }

        private void ListBox02_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox02.SelectedItem == null)
                return;

            ListBox03.ItemsSource = null;
            ListBox04.ItemsSource = null;
            ListBox05.Items.Clear();

            _order = ListBox02.SelectedItem as Orders;

            using (var db = new NorthwindEntities())
            {
                _orderDetails = db.Order_Details.Where(od => od.OrderID == _order.OrderID).ToList();
                _products = new List<Products>();
                ListBox03.ItemsSource = _orderDetails;
                ListBox03.DisplayMemberPath = "ProductID";
                foreach (var item in _orderDetails)
                {
                    _product = db.Products.Where(p => p.ProductID == item.ProductID).FirstOrDefault();

                    _products.Add(_product);

                }
                ListBox04.ItemsSource = null;
                ListBox04.ItemsSource = _products;
                ListBox04.DisplayMemberPath = "ProductName";
            }
        }

        private void ListBox03_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox03.SelectedItem == null)
                return;
        }

        private void ListBox04_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox04.SelectedItem == null)
                return;

            _product = ListBox04.SelectedItem as Products;

            ListBox05.Items.Clear();
            ListBox05.Items.Add($"ID: {_product.ProductID}");
            ListBox05.Items.Add($"Name: {_product.ProductName}");
            ListBox05.Items.Add($"Category ID: {_product.CategoryID}");
            ListBox05.Items.Add($"Price: £{Math.Round(Convert.ToDouble(_product.UnitPrice), 2)}");
            ListBox05.Items.Add($"In stock: {_product.UnitsInStock}");
        }

        private void ListBox05_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox05.SelectedItem == null)
                return;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customers
            {
                CustomerID = Box1.Text,
                CompanyName = Box2.Text,
                ContactName = Box3.Text,
                ContactTitle = Box4.Text,
                Address = Box5.Text,
                City = Box6.Text,
                Region = Box7.Text,
                PostalCode = Box8.Text,
                Country = Box9.Text,
                Phone = Box10.Text,
                Fax = Box11.Text
            };

            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(newCustomer);

                // write changes to db
                db.SaveChanges();

                // refresh the screen
                ListBox01.ItemsSource = null;
                ListBox02.ItemsSource = null;
                ListBox03.ItemsSource = null;
                ListBox04.ItemsSource = null;
                _customers = db.Customers.ToList();

                ListBox01.ItemsSource = _customers;
                ListBox01.DisplayMemberPath = "CompanyName";
            }
        }

        public void SetCustomerFieldsDescription()
        {
            Block1.Text = "CustomerID:";
            Block2.Text = "Company name:";
            Block3.Text = "Contact name:";
            Block4.Text = "Contact title:";
            Block5.Text = "Address:";
            Block6.Text = "City:";
            Block7.Text = "Region:";
            Block8.Text = "Postal code:";
            Block9.Text = "Country:";
            Block10.Text = "Phone:";
            Block11.Text = "Fax:";
        }

        public void SetCustomerFieldsData()
        {
            _customer = ListBox01.SelectedItem as Customers;

            Box1.Text = _customer.CustomerID;
            Box2.Text = _customer.CompanyName;
            Box3.Text = _customer.ContactName;
            Box4.Text = _customer.ContactTitle;
            Box5.Text = _customer.Address;
            Box6.Text = _customer.City;
            Box7.Text = _customer.Region;
            Box8.Text = _customer.PostalCode;
            Box9.Text = _customer.Country;
            Box10.Text = _customer.Phone;
            Box11.Text = _customer.Fax;
        }

        public void SetOrderFieldsDescription()
        {
            Block1.Text = "Customer ID:";
            Block2.Text = "Employee ID:";
            Block3.Text = "Order date:";
            Block4.Text = "Required date:";
            Block5.Text = "Shipped date:";
            Block6.Text = "City:";
            Block7.Text = "Region:";
            Block8.Text = "Postal code:";
            Block9.Text = "Country:";
            Block10.Text = "Phone:";
            Block11.Text = "Fax:";
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _customer = ListBox01.SelectedItem as Customers;

            using (var db = new NorthwindEntities())
            {
                if (_customer != null)
                {
                    Customers customerToEdit = db.Customers.Where(c => c.CustomerID == _customer.CustomerID).First();
                    customerToEdit.CustomerID = Box1.Text;
                    customerToEdit.CompanyName = Box2.Text;
                    customerToEdit.ContactName = Box3.Text;
                    customerToEdit.ContactTitle = Box4.Text;
                    customerToEdit.Address = Box5.Text;
                    customerToEdit.City = Box6.Text;
                    customerToEdit.Region = Box7.Text;
                    customerToEdit.PostalCode = Box8.Text;
                    customerToEdit.Country = Box9.Text;
                    customerToEdit.Phone = Box10.Text;
                    customerToEdit.Fax = Box11.Text;
                }
                // write changes to db
                db.SaveChanges();

                // refresh the screen
                ListBox01.ItemsSource = null;
                ListBox02.ItemsSource = null;
                ListBox03.ItemsSource = null;
                ListBox04.ItemsSource = null;
                _customers = db.Customers.ToList();

                ListBox01.ItemsSource = _customers;
                ListBox01.DisplayMemberPath = "CompanyName";
            }
            _fieldData.ForEach(fd => fd.Clear());
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            AddButton.IsEnabled = true;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_customer == null)
                return;

            // select customer from database
            using (var db = new NorthwindEntities())
            {
                Customers customerToDelete = db.Customers.Where(c => c.CustomerID == _customer.CustomerID).FirstOrDefault();
                db.Customers.Remove(customerToDelete);
                db.SaveChanges();

                // refresh the screen
                ListBox01.ItemsSource = null;
                ListBox02.ItemsSource = null;
                ListBox03.ItemsSource = null;
                ListBox04.ItemsSource = null;
                _customers = db.Customers.ToList();

                ListBox01.ItemsSource = _customers;
                ListBox01.DisplayMemberPath = "CompanyName";
            }

            _fieldData.ForEach(fd => fd.Clear());
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            AddButton.IsEnabled = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _fieldData.ForEach(fd => fd.Clear());
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            AddButton.IsEnabled = true;
        }
    }
}
