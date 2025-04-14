using System.Windows;
using System.Windows.Controls;

namespace Pancakes
{
    /// <summary>
    /// Interaction logic for NumberBox.xaml
    /// </summary>
    public partial class NumberBox : UserControl
    {
        public int Number
        {
            get => int.Parse(textbox.Text);
            set
            {
                if (value > 0) textbox.Text = value.ToString();
                else textbox.Text = "1";
            }
        }
        public NumberBox()
        {
            InitializeComponent();
        }
        private void plusButton_Click(object sender, RoutedEventArgs e) => Number++;
        private void minusButton_Click(object sender, RoutedEventArgs e) => Number--;
        string PrevText = "";
        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int output;
            if (int.TryParse(textbox.Text, out output) && output > 0)
            {
                PrevText = textbox.Text;
            }
            else
            {
                int PrevSelectStart = textbox.SelectionStart;
                int PrevSelectLength = textbox.SelectionLength;
                textbox.Text = PrevText;
                textbox.SelectionStart = PrevSelectStart;
                textbox.SelectionLength = PrevSelectLength;
            };
        }
    }
}
