using FluentAssertions;
using TemperatureConverter;
using TemperatureConverter.Controllers;

namespace TemperatureConverterTests
{
	public class TemperatureConverterTest
	{
		CalculatorController calculator = new CalculatorController();

		[Theory]
		[InlineData("32", 89.60, 0.01)]
		[InlineData("14,45", 58.01, 0.01)]
		[InlineData("9999999999999999", 18000000000000032.00, 1.00)]
		public void Celsius_to_fahrenheit_conversion_success(string c, double result, double tolerance)
		{
			double value = Double.Parse(c);

			double calculatedValue = calculator.CalculateTemperature(value, "c", "f");

			calculatedValue.Should().BeApproximately(result, tolerance);
		}


		[Theory]
		[InlineData("27", 300.15, 0.01)]
		[InlineData("67,54", 340.69, 0.01)]
		[InlineData("9999999999999999", 10000000000000274.00, 1.00)]
		public void Celsius_to_kelvin_conversion_success(string c, double result, double tolerance)
		{
			double value = Double.Parse(c);

			double calculatedValue = calculator.CalculateTemperature(value, "c", "k");

			calculatedValue.Should().BeApproximately(result, tolerance);
		}


		[Theory]
		[InlineData("100", 37.78, 0.01)]
		[InlineData("43,56", 6.42, 0.01)]
		[InlineData("9999999999999999", 5555555555555538.00, 1.00)]
		public void Fahrenheit_to_celsius_conversion_success(string c, double result, double tolerance)
		{
			double value = Double.Parse(c);

			double calculatedValue = calculator.CalculateTemperature(value, "f", "c");

			calculatedValue.Should().BeApproximately(result, tolerance);
		}


		[Theory]
		[InlineData("120", 322.04, 0.01)]
		[InlineData("156,89", 342.53, 0.01)]
		[InlineData("9999999999999999", 5555555555555812.00, 1.00)]
		public void Fahrenheit_to_kelvin_conversion_success(string c, double result, double tolerance)
		{
			double value = Double.Parse(c);

			double calculatedValue = calculator.CalculateTemperature(value, "f", "k");

			calculatedValue.Should().BeApproximately(result, tolerance);
		}


		[Theory]
		[InlineData("0", -273.15, 0.01)]
		[InlineData("38,7", -234.45, 0.01)]
		[InlineData("9999999999999999", 9999999999999726.00, 1.00)]
		public void Kelvin_to_celsius_conversion_success(string c, double result, double tolerance)
		{
			double value = Double.Parse(c);

			double calculatedValue = calculator.CalculateTemperature(value, "k", "c");

			calculatedValue.Should().BeApproximately(result, tolerance);
		}


		[Theory]
		[InlineData("200", -99.67, 0.01)]
		[InlineData("452,48", 354.79, 0.01)]
		[InlineData("9999999999999999", 17999999999999540.00, 1.00)]
		public void Kelvin_to_fahrenheit_conversion_success(string c, double result, double tolerance)
		{
			double value = Double.Parse(c);

			double calculatedValue = calculator.CalculateTemperature(value, "k", "f");

			calculatedValue.Should().BeApproximately(result, tolerance);
		}
	}
}