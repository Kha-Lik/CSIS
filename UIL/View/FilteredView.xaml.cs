using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CSIS_UI_WPF.View
{
    public partial class FilteredView : Window
    {
        public FilteredView()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}