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

namespace labx_01_databases_trainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customers> customers = new List<Customers>();

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }


        void Initialize()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
            }

            foreach(Customers c in customers)
            {
                ListBox01.Items.Add(c.ContactName);
            }
        }
        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
