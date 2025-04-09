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
    }
    struct Pancake
    {
        public static int BasePrice = 100;
        public static Dictionary<string, double> DoughTypes = new Dictionary<string, double>
        {
            ["normál"] = 1,
            ["nem normál"] = 1.2
        };
        public static Dictionary<string, double> FillingTypes = new Dictionary<string, double>
        {
            ["kakaós"] = 1,
            ["túrós"] = 1,
            ["lekváros"] = 1
        };

        public int N { get; set; }
        public string Dough { get; set; }
        public string Filling { get; set; }
        public int Price => (int)(BasePrice * N * FillingTypes[Filling] * DoughTypes[Dough]);

        public Pancake(int n, string dough, string filling)
        {
            N = n;
            Dough = dough;
            Filling = filling;
        }
        public override string ToString() => $"{N} db {Dough} tésztás {Filling} palacsinta\t{Price} Ft";
    }
}
