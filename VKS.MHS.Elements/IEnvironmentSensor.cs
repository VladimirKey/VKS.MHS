using System;
namespace VKS.MHS.Elements
{
	/// <summary>
	/// Environment sensor capabilities flags.
	/// </summary>
	[Flags]
	public enum EnvironmentSensorCapabilities
	{
		/// <summary>
		/// Sensor can provide temperature data.
		/// </summary>
		Temperature = 1,

		/// <summary>
		/// Sensor can provide humidity data.
		/// </summary>
		Humidity = 2,

		/// <summary>
		/// Sensor can provide atmospheric pressure data.
		/// </summary>
		Pressure = 4,

		/// <summary>
		/// Sensor can provide wind direction data.
		/// </summary>
		WindDirection = 8,

		/// <summary>
		/// Sensor can provide win velocity data.
		/// </summary>
		WindVelocity = 16,

		/// <summary>
		/// Sensor can provide data for luminocity of solar light.
		/// </summary>
		Luminocity = 32,

		/// <summary>
		/// Sensor can provide UV intensity data.
		/// </summary>
		UVIntensity = 64,

		/// <summary>
		/// Sensor has rain gauge.
		/// </summary>
		RainGauge = 128
	}

	/// <summary>
	/// Environment sensor location.
	/// </summary>
	public enum EnvironmentSensorLocation
	{
		/// <summary>
		/// Indoor location.
		/// </summary>
		Indoor,

		/// <summary>
		/// Outdoor location.
		/// </summary>
		Outdoor
	}

	public interface IEnvironmentSensor: ISensor<EnvironmentData>
	{
		/// <summary>
		/// Gets the sensor location.
		/// </summary>
		/// <value>The sensor location.</value>
		EnvironmentSensorLocation SensorLocation { get; }

		/// <summary>
		/// Gets the capabilities of environment sensor.
		/// </summary>
		/// <value>The capabilities of environment sensor.</value>
		EnvironmentSensorCapabilities Capabilities { get; }
	}
}
