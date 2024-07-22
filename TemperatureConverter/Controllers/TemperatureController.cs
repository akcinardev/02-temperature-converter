using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TemperatureConverter.Controllers
{
	public class TemperatureController
	{
        private DataTable TemperatureDataTable { get; }

        public TemperatureController()
        {
            TemperatureDataTable = CreateTemperatureTable();
		}

		public void BindDataToComboBox(ComboBox comboBox)
		{
			comboBox.ItemsSource = TemperatureDataTable.DefaultView;
			comboBox.DisplayMemberPath = "Temperature";
			comboBox.SelectedValuePath = "Symbol";
			comboBox.SelectedIndex = 0;
		}

		private DataTable CreateTemperatureTable()
        {
			DataTable temperatureDatas = new DataTable();
			temperatureDatas.Columns.Add("Temperature");
			temperatureDatas.Columns.Add("Symbol");

			temperatureDatas.Rows.Add("----", "-");
			temperatureDatas.Rows.Add("Celcius (°C)", "c");
			temperatureDatas.Rows.Add("Fahrenheit (°F)", "f");
			temperatureDatas.Rows.Add("Kelvin (°K)", "k");

			return temperatureDatas;
		}
    }
}
