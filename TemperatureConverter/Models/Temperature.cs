using System.Data;
using System.Windows.Controls;

namespace TemperatureConverter.Models
{
	public class Temperature
	{
		public string? Name { get; set; }
		public string? Symbol { get; set; }

        public Temperature(ComboBox cBox)
        {
            Name = GetTemperatureInfoFromCbox(cBox);
            Symbol = cBox.SelectedValue.ToString();
        }

		private string? GetTemperatureInfoFromCbox(ComboBox cBox)
		{
			DataRowView selectedRow = (DataRowView)cBox.SelectedItem;
			string? selectedTemperature = selectedRow["Temperature"].ToString();
			return selectedTemperature;
		}
	}
}
