using System;
namespace VKS.MHS.Elements
{
	/// <summary>
	/// Abstraction class for sensor data.
	/// </summary>
	public abstract class SensorData
	{
		/// <summary>
		/// Gets or sets the timestamp of sensor data package.
		/// </summary>
		/// <value>The timestamp.</value>
		public DateTime Timestamp
		{
			get;
			protected set;
		}
	}
}
