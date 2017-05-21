using System;

namespace VKS.MHS.Elements.NodeMCU.Datagrams
{

	[Datagram("00000000-0000-0000-0000-000000000001")]
	public class DiscoveredDatagram: IngoingDatagram
	{

		public string HardwareVersion
		{
			get;
			set;
		}

		public string FirmwareVersion
		{
			get;
			set;
		}

		public string Manufacturer
		{
			get;
			set;
		}

		public bool IsInitialized
		{
			get;
			set;
		}

	}
}
