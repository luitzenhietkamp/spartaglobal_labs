using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace hw_104_WPF_Northwind_Entity_v02
{
    public abstract class TableView
    {
        #region internal fields
        // Reference to the stack of TableViews
        protected Stack<TableView> _viewStack;

        // Grid in which the current view is located
        protected Grid ViewArea;

        // The DataGrid of the current view
        protected DataGrid DGTableView;

        // StackPanel for the buttons
        protected StackPanel _stackPanel;

        // Buttons belonging to the current view
        protected List<Button> _buttons;
        #endregion

        // Name of te current view
        public string Name { get; set; }

        public TableView(Grid viewArea, Stack<TableView> viewStack)
        {
            _viewStack = viewStack;
            this.ViewArea = viewArea;
            SetContentView();
            SetButtonView();
        }

        #region CreateView
        /// <summary>
        /// Sets the content of the associated table to the ViewArea
        /// </summary>
        public abstract void SetContentView();

        /// <summary>
        /// Sets the Buttons associated with the table
        /// </summary>
        public void SetButtonView()
        {
            // Create stackpanel
            _stackPanel = new StackPanel();
            ViewArea.Children.Add(_stackPanel);
            Grid.SetColumn(_stackPanel, 1);

            // Initialize button list
            _buttons = new List<Button>();

            AddInspectButton();
            AddBackButton();
        }
        #endregion

        /// <summary>
        /// Fetches the data from the database
        /// </summary>
        public abstract void FetchData();

        #region Click handlers
        /// <summary>
        /// Method that's called when a Data Item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void DataItemClicked(object sender, EventArgs e);

        /// <summary>
        /// Method that's called when a button in the navigation pane is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NavButtonClicked(object sender, RoutedEventArgs e)
        {
            var buttonClickedAsArray = ((string)((Button)sender).Content).Split(' ');
            // Don't do anything if no field has been selected yet
            if (buttonClickedAsArray[1] == "table")
                return;

            if (buttonClickedAsArray[0] == "Inspect")
                Inspect(buttonClickedAsArray[1], "*");

            if (buttonClickedAsArray[1] == "Back")
            {
                _viewStack.Pop();
                _viewStack.Peek().Activate();
            }
        }
        #endregion

        /// <summary>
        /// Method that is called when the Inspect button is clicked.
        /// </summary>
        /// <param name="tableName">The associated table</param>
        /// <param name="id">The associated ID</param>
        public void Inspect(string tableName, string id)
        {
            this.Deactivate();
            switch (tableName)
            {
                case "Categories":
                    _viewStack.Push(new CategoriesView(ViewArea, _viewStack));
                    break;
                case "Customers":
                    _viewStack.Push(new CustomersView(ViewArea, _viewStack));
                    break;
                case "Employees":
                    _viewStack.Push(new EmployeesView(ViewArea, _viewStack));
                    break;
                case "Order_Details":
                    _viewStack.Push(new Order_DetailsView(ViewArea, _viewStack));
                    break;
                case "Orders":
                    _viewStack.Push(new OrdersView(ViewArea, _viewStack));
                    break;
                case "Products":
                    _viewStack.Push(new ProductsView(ViewArea, _viewStack));
                    break;
                case "Region":
                    _viewStack.Push(new RegionView(ViewArea, _viewStack));
                    break;
                case "Shippers":
                    _viewStack.Push(new ShippersView(ViewArea, _viewStack));
                    break;
                case "Suppliers":
                    _viewStack.Push(new SuppliersView(ViewArea, _viewStack));
                    break;
                case "Territories":
                    _viewStack.Push(new TerritoriesView(ViewArea, _viewStack));
                    break;
                default:
                    return;
            }
        }

        public void Activate()
        {
            ViewArea.Children.Add(DGTableView);
            ViewArea.Children.Add(_stackPanel);
        }

        public void Deactivate()
        {
            ViewArea.Children.Clear();
        }

        #region Buttons
        public void AddInspectButton()
        {
            // Create button
            var button = new Button
            {
                Name = "inspect",
                Content = "Inspect table",
                Margin = new Thickness(3, 3, 3, 0)
            };
            button.Click += NavButtonClicked;

            // Add button
            _stackPanel.Children.Add(button);
            _buttons.Add(button);
        }

        public void AddBackButton()
        {
            // Create button
            var button = new Button
            {
                Name = "Back",
                Content = "Go Back",
                Margin = new Thickness(3, 3, 3, 0)
            };
            button.Click += NavButtonClicked;

            // Add button
            _stackPanel.Children.Add(button);
            _buttons.Add(button);
        }

        #endregion
    }
}
