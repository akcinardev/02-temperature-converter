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

			string? fromTemperature = FormatTemperatureInfo(fromComboBox);
			string? toTemperature = FormatTemperatureInfo(toComboBox);

			if (!string.IsNullOrEmpty(temperatureTbox.Text) && fromCbox != "-" && toCbox != "-")
			{
				try
				{
					double value = Double.Parse(temperatureTbox.Text);
					double result = calculator.CalculateTemperature(value, fromCbox, toCbox);
					resultTbox.Content = $"{value} {fromTemperature} = {result} {toTemperature}";
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

		private string? FormatTemperatureInfo(ComboBox cBox)
		{
			DataRowView selectedRow = (DataRowView)cBox.SelectedItem;
			string? selectedTemperature = selectedRow["Temperature"].ToString();
			return selectedTemperature;
		}
	}
}