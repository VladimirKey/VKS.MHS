using System;


namespace VKS.MHS.Elements.NodeMCU
{
	public class EnvironmentSensorNode : NodeElement, IEnvironmentSensor
	{
		public EnvironmentSensorCapabilities Capabilities
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public EnvironmentData LatestData
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public SensorEventType SensorEventGenerationType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public EnvironmentSensorLocation SensorLocation
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public event SensorDataReceived<EnvironmentData> DataRecieved;

		public void RequestData()
		{
			throw new NotImplementedException();
		}
	}
}
