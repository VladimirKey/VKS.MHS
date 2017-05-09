using System;
namespace VKS.MHS.Elements
{

	/// <summary>
	/// Environment data sensor package.
	/// All data values provided in metric system.
	/// </summary>
	public class EnvironmentData: SensorData, IFormattable
	{
		/// <summary>
		/// Gets or sets the temperature in Kelvins.
		/// </summary>
		/// <value>The temperature in Kelvins or <c>null</c> if
		/// data not provided.</value>
		public double? Temperature { get; set; }

		/// <summary>
		/// Gets or sets the relative humidity in percents.
		/// </summary>
		/// <value>The relative humidity in percents.</value>
		public double? Humidity { get; set; }

		/// <summary>
		/// Gets or sets the pressure in Pa.
		/// </summary>
		/// <value>The pressure in Pa.</value>
		public double? Pressure { get; set; }

		/// <summary>
		/// Gets or sets the wind direction in degrees, where North is 0 | 360.
		/// </summary>
		/// <value>The wind direction in degrees.</value>
		public double? WindDirection { get; set; }

		/// <summary>
		/// Gets or sets the wind velocity in meters/second.
		/// </summary>
		/// <value>The wind velocity in m/s.</value>
		public double? WindVelocity { get; set; }

		/// <summary>
		/// Gets or sets the luminosity in lumenes.
		/// </summary>
		/// <value>The luminosity of environment in Lumenes.</value>
		public double? Luminosity { get; set; }

		/// <summary>
		/// Gets or sets the UV solarization intensity in Lux.
		/// </summary>
		/// <value>The UV solarization intensity in Lux.</value>
		public double? UVIntensity { get; set; }

		/// <summary>
		/// Gets or sets the rain gauge in meters.
		/// </summary>
		/// <value>The rain gauge in meters.</value>
		public double? RainGauge { get; set; }

		/// <summary>
		/// Convert sensor data value to a formattable string.
		/// Possible format strings are:
		/// <list type="unordered">
		/// 	<item><c>g</c> - Generic format, that contains all data.</item>
		/// 	<item><c>t</c> - Temperature. </item>
		/// </list>
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="format">Format.</param>
		/// <param name="formatProvider">Format provider.</param>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			//TODO: Implement formatting support for weather data.
			throw new NotImplementedException();
		}
	}
}
