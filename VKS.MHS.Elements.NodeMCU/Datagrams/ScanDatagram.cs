using System;
using System.Net;

namespace VKS.MHS.Elements.NodeMCU.Datagrams
{
	/// <summary>
	/// Datagram for Scan command.
	/// </summary>
	/// <remarks>
	/// This command initiates Scan procedure over network. Every node in network
	/// listen for UDP broadcast on 54055 port. This command send to this port as
	/// UDP broadcast.
	/// When node recieves broadcast it should response with <see cref="DiscoveredDatagram"/>
	/// to a specified in ScanDatagram ip endpoint.
	/// </remarks>
	[Datagram("00000000-0000-0000-0000-000000000000")]
	public class ScanDatagram: OutgoingDatagram
	{
		public ScanDatagram(IPEndPoint AServerEndPoint)
		{

			if (AServerEndPoint == null)
				throw new ArgumentNullException(nameof(AServerEndPoint));

			this.AuthToken = null;
			this.Username = "";
			this.Password = "";
			this.ClassId = "server::server";
			this.DatagramTypeId = Guid.Empty;
			this.Enabled = true;
            this.Identifier = Guid.Empty;
			this.IsFaulty = false;
			this.FaultCode = null;
			this.FaultMessage = "OK";
			this.Version = 1.0;
			this.IPAddress = AServerEndPoint.Address.ToString();
			this.Location = null;
			this.Port = AServerEndPoint.Port;
		}
	}
}
