using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace RobotProgrammer
{
    public partial class OptionWindow : Window
    {
        private static readonly Regex numberRegex = new Regex("[^0-9.]+");

        public string Port { get; set; }
        public string Step { get; set; }
        public string Wheel { get; set; }
        public string Axle { get; set; }

        public OptionWindow()
        {
            Port = "OUT_AC";
            Step = "500";
            Wheel = "5.5";
            Axle = "7.5";
            InitializeComponent();
        }

        private void StepTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = numberRegex.IsMatch(e.Text);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
