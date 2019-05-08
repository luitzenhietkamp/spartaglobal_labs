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

namespace labx_01_databasesWithWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        // Create own Initialisation method
        void Initialise()
        {
            List<CustomObject> query = NorthwindQueries.OrderSummary();

            foreach (var item in query)
            {
                //QueryResults.Items.Add(item.OrderDate);
                
                //QueryResults.Items.Add($"{item.CustomerName} on {item.OrderDate.Value.ToShortDateString()} placed order {item.OrderID}.");
                QueryResults.Items.Add($"{item.CustomerName} on {item.OrderDate:dd-MM-yyyy} placed order {item.OrderID}.");
            }
        }

        private void QueryResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public static class NorthwindQueries
        {
            public static List<CustomObject> OrderSummary()
            {
                List<CustomObject> result;
                var entryList = new List<CustomObject>();

                using (var db = new NorthwindEntities())
                {
                    result = (from cust in db.Customers
                              join ord in db.Orders on cust.CustomerID equals ord.CustomerID
                              select new CustomObject
                              {
                                  CustomerName = cust.ContactName,
                                  OrderDate = ord.OrderDate,
                                  OrderID = ord.OrderID
                              }).ToList();
                }
                return result;
            }
        }

        public class CustomObject
        {
            public string CustomerName { get; set; }
            public DateTime? OrderDate { get; set; }
            public int OrderID { get; set; }
        }
    }
}
