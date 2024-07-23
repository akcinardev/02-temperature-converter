namespace TemperatureConverter.Controllers
{
	public class CalculatorController
	{
		private const string Celsius = "c";
		private const string Fahrenheit = "f";
		private const string Kelvin = "k";
		public double CalculateTemperature(double value, string? from, string? to)
		{
			if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
			{
				throw new ArgumentException("Temperature unit is null or empty!");
			}

			if (from == to)
			{
				return FormatResult(value);
			}

			return from switch
			{
				Celsius when to == Fahrenheit => FormatResult(CelciusToFahrenheit(value)),
				Celsius when to == Kelvin => FormatResult(CelciusToKelvin(value)),
				Fahrenheit when to == Celsius => FormatResult(FahrenheitToCelsius(value)),
				Fahrenheit when to == Kelvin => FormatResult(FahrenheitToKelvin(value)),
				Kelvin when to == Celsius => FormatResult(KelvinToCelsius(value)),
				Kelvin when to == Fahrenheit => FormatResult(KelvinToFahrenheit(value)),
				_ => throw new ArgumentException("Invalid temperature")
			};
		}

		private double CelciusToFahrenheit(double c)
		{
			// Celsius to Fahrenheit: F = C(9/5) + 32
			return (c * (9.0 / 5.0)) + 32.0;
		}

		private double CelciusToKelvin(double c)
		{
			// Celsius to Kelvin: K = C + 273.15
			return c + 273.15;
		}

		private double FahrenheitToCelsius(double f)
		{
			// Fahrenheit to Celcius: C = (F-32) (5/9)
			return (f - 32.0) * (5.0 / 9.0);
		}

		private double FahrenheitToKelvin(double f)
		{
			// Fahrenheit to Kelvin: K = (F-32) (5/9) + 273.15
			return (f - 32.0) * (5.0 / 9.0) + 273.15;
		}

		private double KelvinToCelsius(double k)
		{
			// Kelvin to Celcius: C = K - 273.15
			return k - 273.15;
		}

		private double KelvinToFahrenheit(double k)
		{
			// Kelvin to Fahrenheit: F = (K-273.15) (9/5) + 32
			return (k - 273.15) * (9.0 / 5.0) + 32.0;
		}

		private double FormatResult(double result)
		{
			return Math.Round(result, 2);
		}
	}
}
