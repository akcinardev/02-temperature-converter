using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TemperatureConverter.Controllers;
using static System.Net.Mime.MediaTypeNames;

namespace TemperatureConverter
{
	public partial class MainWindow : Window
	{
		TemperatureController temperature = new TemperatureController();
		CalculatorController calculator = new CalculatorController();
		public MainWindow()
		{
			InitializeComponent();
			
			temperature.BindDataToComboBox(fromComboBox);
			temperature.BindDataToComboBox(toComboBox);			
		}

		private void ConvertButton_Clicked(object sender, RoutedEventArgs e)
		{
			string? fromCbox = fromComboBox.SelectedValue.ToString();
			string? toCbox = toComboBox.SelectedValue.ToString();

			if (!string.IsNullOrEmpty(temperatureTbox.Text) && fromCbox != "-" && toCbox != "-")
			{
				double value = Double.Parse(temperatureTbox.Text);
				double result = calculator.CalculateTemperature(value, fromCbox, toCbox);
				resultTbox.Content = $"{result} {fromCbox} = {result} {toCbox}";
			}
			else
			{
				MessageBox.Show("Please enter a valid number and choose the temperatures!");
			}

			
        }

		private void IsInputValid(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9,-]+");
			e.Handled = regex.IsMatch(e.Text);
		}
	}
}