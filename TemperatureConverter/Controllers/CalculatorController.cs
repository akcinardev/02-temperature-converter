using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TemperatureConverter.Controllers
{
	public class CalculatorController
	{
		public double CalculateTemperature(double value, string? from, string? to)
		{
			if (from == to)
			{
				return value;
			}
			switch (from)
			{
				case "c":
					if (to == "f")
						return CelciusToFahrenheit(value);
					else if (to == "k")
						return CelciusToKelvin(value);
					break;
				case "f":
					if (to == "c")
						return FahrenheitToCelsius(value);
					else if (to == "k")
						return FahrenheitToKelvin(value);
					break;
				case "k":
					if (to == "c")
						return KelvinToCelsius(value);
					else if (to == "f")
						return KelvinToFahrenheit(value);
					break;
				default:
					throw new ArgumentException("Invalid input");
			}
			throw new ArgumentException("Invalid input");
		}

		public double CelciusToFahrenheit(double c)
		{
			// Celsius to Fahrenheit: F = C(9/5) + 32
			return (c * (9 / 5)) + 32;
		}

		public double CelciusToKelvin(double c)
		{
			// Celsius to Kelvin: K = C + 273.15
			return c + 273.15;
		}

		public double FahrenheitToCelsius(double f)
		{
			// Fahrenheit to Celcius: C = (F-32) (5/9)
			return (f - 32) * (5 / 9);
		}

		public double FahrenheitToKelvin(double f)
		{
			// Fahrenheit to Kelvin: K = (F-32) (5/9) + 273.15
			return (f - 32) * (5 / 9) + 273.19;
		}

		public double KelvinToCelsius(double k)
		{
			// Kelvin to Celcius: C = K - 273.15
			return k - 273.15;
		}

		public double KelvinToFahrenheit(double k)
		{
			// Kelvin to Fahrenheit: F = (K-273.15) (9/5) + 32
			return (k - 273.15) * (9 / 5) + 32;
		}
	}
}
