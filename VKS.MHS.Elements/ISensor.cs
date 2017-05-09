using System;
namespace VKS.MHS.Elements
{
	/// <summary>
	/// Determines logic of sensor data provider.
	/// </summary>
	public enum SensorEventType
	{
		/// <summary>
		/// Sensor data provided periodically by internal or external timer/interval.
		/// </summary>
		Periodic,

		/// <summary>
		/// Sensor data provided when data changed.
		/// </summary>
		OnValueChange,

		/// <summary>
		/// Sensor data provided by demand of caller.
		/// </summary>
		OnDemand
	}

	/// <summary>
	/// Sensor data recieved event arguments.
	/// </summary>
	[Serializable]
	public sealed class SensorDataRecievedEventArgs<TData> : EventArgs where TData : SensorData, new()
	{
		/// <summary>
		/// Gets or sets the data package.
		/// </summary>
		/// <value>The data package.</value>
		public TData DataPackage { get; set; }
	}

	/// <summary>
	/// Sensor data received event delegate.
	/// </summary>
	public delegate void SensorDataReceived<TData>(SensorDataRecievedEventArgs<TData> AArgs) where TData : SensorData, new();

	/// <summary>
	/// Interface for Sensors hardware and logic.
	/// </summary>
	public interface ISensor<TData>: IElement where TData:SensorData, new()
	{
		/// <summary>
		/// Gets the latest sensor data.
		/// </summary>
		/// <value>The latest sensor data or null if no data exists.</value>
		TData LatestData { get; }

		/// <summary>
		/// Occurs when sensor data recieved.
		/// </summary>
		event SensorDataReceived<TData> DataRecieved;

		/// <summary>
		/// Gets the type of the sensor event generation.
		/// </summary>
		/// <value>The type of the sensor event generation.</value>
		SensorEventType SensorEventGenerationType { get; }

		/// <summary>
		/// Requests the sensor data from source.
		/// </summary>
		void RequestData();
	}
}
