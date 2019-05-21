using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace hw_104_WPF_Northwind_Entity_v02
{
    public class GenericTableView<T> : TableView where T: class
    {
        private List<T> _data;

        public GenericTableView (Grid viewArea, Stack<TableView> viewStack) : base(viewArea, viewStack)
        {
            AddBackButton();
        }

        public override void DataItemClicked(object sender, EventArgs e)
        {
            if (DGTableView.CurrentCell == null)
                return;
            var currentCell = DGTableView.CurrentCell;
            
            _buttons.Find(b => b.Name == "inspect").Content = $"{currentCell}";
        }

        public override void FetchData()
        {
            using (var db = new NorthwindEntities())
            {
                _data = db.Set<T>().ToList();
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

        public override void Inspect(string tableName, string id)
        {
            this.Deactivate();
            switch (tableName)
            {
                case "Categories":
                    _viewStack.Push(new GenericTableView<Categories>(ViewArea, _viewStack));
                    break;
                case "Customers":
                    _viewStack.Push(new GenericTableView<Customers>(ViewArea, _viewStack));
                    break;
                case "Employees":
                    _viewStack.Push(new GenericTableView<Employees>(ViewArea, _viewStack));
                    break;
                case "Order_Details":
                    _viewStack.Push(new GenericTableView<Order_Details>(ViewArea, _viewStack));
                    break;
                case "Orders":
                    _viewStack.Push(new GenericTableView<Orders>(ViewArea, _viewStack));
                    break;
                case "Products":
                    _viewStack.Push(new GenericTableView<Products>(ViewArea, _viewStack));
                    break;
                case "Region":
                    _viewStack.Push(new GenericTableView<Region>(ViewArea, _viewStack));
                    break;
                case "Shippers":
                    _viewStack.Push(new GenericTableView<Shippers>(ViewArea, _viewStack));
                    break;
                case "Suppliers":
                    _viewStack.Push(new GenericTableView<Suppliers>(ViewArea, _viewStack));
                    break;
                case "Territories":
                    _viewStack.Push(new GenericTableView<Territories>(ViewArea, _viewStack));
                    break;
                default:
                    return;
            }
        }
    }
}
