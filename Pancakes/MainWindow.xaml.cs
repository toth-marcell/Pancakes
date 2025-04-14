using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Pancakes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pancake> pancakes = new List<Pancake>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (KeyValuePair<string, double> dough in Pancake.DoughTypes) doughField.Items.Add(new ComboBoxItem { Content = dough.Key });
            foreach (KeyValuePair<string, double> filling in Pancake.FillingTypes) fillingField.Items.Add(new ComboBoxItem { Content = filling.Key });
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Pancake pancake = new Pancake(nField.Number, doughField.Text, fillingField.Text);
            pancakes.Add(pancake);
            outputPanel.Children.RemoveAt(outputPanel.Children.Count - 1);
            outputPanel.Children.Add(new Label { Content = pancake.ToString() });
            outputPanel.Children.Add(new Label { Content = "Végösszeg: " + pancakes.Select(p => p.Price).Sum() + " Ft" });
        }
        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter writer = new StreamWriter("order.csv", false, Encoding.UTF8);
            writer.WriteLine("n,dough,filling,price");
            foreach (Pancake pancake in pancakes) writer.WriteLine(pancake.ToCSV());
            writer.Close();
            MessageBox.Show("Siker!");
            Close();
        }
    }
}
