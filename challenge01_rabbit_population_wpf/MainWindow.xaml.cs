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
using challenge01_rabbit_population;

namespace challenge01_rabbit_population_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int time;

        public MainWindow()
        {
            InitializeComponent();
            time = 0;
        }

        private void StartSimulation_Click(object sender, RoutedEventArgs e)
        {
            Listbox_Results.Items.Clear();
            var result = Program.RabbitSimulation(time);
            for (int i = 0; i < result.Count; i++)
            {
                Listbox_Results.Items.Add($"There are {result[i]} rabbits after {i} seconds");
            }
            
            ++time;
        }
    }
}
