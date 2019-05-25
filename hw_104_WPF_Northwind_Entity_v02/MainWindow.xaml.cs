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

    public class NorthwindTable
    {
        public string TableName { get; set; }
    }
    #endregion

}
