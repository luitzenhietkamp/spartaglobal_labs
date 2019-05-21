using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace hw_104_WPF_Northwind_Entity_v02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<TableView> ViewStack;

        public MainWindow()
        {
            InitializeComponent();

            ViewStack = new Stack<TableView>();
            ViewStack.Push(new NorthwindView(ViewArea, ViewStack));
        }
    }

    #region Classes that don't have their own files yet

    public class NorthwindView : TableView
    {
        public NorthwindView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            Name = "Start";
        }

        public override void SetContentView()
        {
            var NWTables = new ObservableCollection<NorthwindTable>
            {
                new NorthwindTable{TableName = "Categories" },
                new NorthwindTable{TableName = "Customers" },
                new NorthwindTable{TableName = "Employees" },
                new NorthwindTable{TableName = "Order_Details" },
                new NorthwindTable{TableName = "Orders" },
                new NorthwindTable{TableName = "Products" },
                new NorthwindTable{TableName = "Region" },
                new NorthwindTable{TableName = "Shippers" },
                new NorthwindTable{TableName = "Territories" }
            };

            DGTableView = new DataGrid
            {
                ItemsSource = NWTables,
                CanUserAddRows = false,
                CanUserDeleteRows = false,
                IsReadOnly = true
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }

        public override void FetchData()
        {
            throw new NotImplementedException();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            if (DGTableView.CurrentItem == null)
                return;
            var table = (NorthwindTable)DGTableView.CurrentItem;
            _buttons.Find(b => b.Name == "inspect").Content = $"Inspect {table.TableName}";
        }
    }

    public class CategoriesView : TableView
    {
        private List<Categories> _data;

        public CategoriesView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Categories.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class CustomersView : TableView
    {
        private List<Customers> _data;

        public CustomersView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Customers.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class EmployeesView : TableView
    {
        private List<Employees> _data;

        public EmployeesView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Employees.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class Order_DetailsView : TableView
    {
        private List<Order_Details> _data;

        public Order_DetailsView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Order_Details.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class OrdersView : TableView
    {
        private List<Orders> _data;

        public OrdersView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Orders.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class ProductsView : TableView
    {
        private List<Products> _data;

        public ProductsView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Products.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class RegionView : TableView
    {
        private List<Region> _data;

        public RegionView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Region.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class ShippersView : TableView
    {
        private List<Shippers> _data;

        public ShippersView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Shippers.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class SuppliersView : TableView
    {
        private List<Suppliers> _data;

        public SuppliersView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Suppliers.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class TerritoriesView : TableView
    {
        private List<Territories> _data;

        public TerritoriesView(Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Territories.ToList();
            }
        }

        public override void SetContentView()
        {
            FetchData();

            DGTableView = new DataGrid
            {
                ItemsSource = _data
            };
            DGTableView.CurrentCellChanged += DataItemClicked;
            ViewArea.Children.Add(DGTableView);
        }
    }

    public class NorthwindTable
    {
        public string TableName { get; set; }
    }
    #endregion

}
