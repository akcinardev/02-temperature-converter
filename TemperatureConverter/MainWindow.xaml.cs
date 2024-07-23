using System.Data;
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
using TemperatureConverter.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TemperatureConverter
{
	public partial class MainWindow : Window
	{
		TemperatureController temperatureController = new TemperatureController();
		CalculatorController calculator = new CalculatorController();
		public MainWindow()
		{
			InitializeComponent();

			temperatureController.BindDataToComboBox(fromComboBox);
			temperatureController.BindDataToComboBox(toComboBox);
		}

		private void ConvertButton_Clicked(object sender, RoutedEventArgs e)
		{
			Temperature fromTemperature = new Temperature(fromComboBox);
			Temperature toTemperature = new Temperature(toComboBox);

			if (!string.IsNullOrEmpty(temperatureTbox.Text) && fromTemperature.Symbol != "-" && toTemperature.Symbol != "-")
			{
				try
				{
					double value = Double.Parse(temperatureTbox.Text);
					double result = calculator.CalculateTemperature(value, fromTemperature.Symbol, toTemperature.Symbol);
					resultTbox.Content = $"{value} {fromTemperature.Name} = {result} {toTemperature.Name}";
				}
				catch (FormatException ex)
				{
					MessageBox.Show($"'{temperatureTbox.Text}' is not a valid number. Please enter a valid number. Use comma (,) for decimals.");
					temperatureTbox.Clear();
					temperatureTbox.Focus();
				}
			}
			else
			{
				MessageBox.Show("Please provide all the necessary fields.");
			}
        }

		private void IsInputValid(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9,-]+");
			e.Handled = regex.IsMatch(e.Text);
		}
	}
}