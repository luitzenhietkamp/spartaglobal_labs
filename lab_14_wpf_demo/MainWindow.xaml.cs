// A small program that introduces WPF
using System.Windows;

namespace lab_14_wpf_demo
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
            Button01.FontSize = 40;
        }

        int counter = 0;

        // Every time Button01 is clicked the counter is increased and
        // its value is displayed in Label01 and ListBox01
        // The font size of the label and button are also increased for every click
        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            ++counter;
            Label01.Content = $"Hey you clicked {counter} times";
            ListBox01.Items.Add($"Hey you clicked {counter} times");
            Label01.FontSize++;
            Button01.FontSize++;
        }

        // Actions for Reset button
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            Label01.Content = $"Hey you clicked {counter} times";
            ListBox01.Items.Clear();
            Label01.FontSize = 11;
        }
    }
}
