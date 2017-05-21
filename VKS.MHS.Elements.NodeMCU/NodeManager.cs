using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace VKS.MHS.Elements.NodeMCU
{
	/// <summary>
	/// Class for management of NodeMCU based elements.
	/// </summary>
	public class NodeManager
	{


		public IReadOnlyDictionary<IPEndPoint, NodeElement> ScanForNodes(int ATimeToLive = 1000)
		{
			return ScanForNodesAsync(ATimeToLive).Result;
		}

		public async Task<IReadOnlyDictionary<IPEndPoint, NodeElement>> ScanForNodesAsync(int ATimeToLive = 1000)
		{
			throw new NotImplementedException();
		}

		protected async Task<IReadOnlyCollection<Datagrams.IngoingDatagram>> SendBroadcast(
			Datagrams.OutgoingDatagram ADatagram,
			bool AWaitForResponse = false)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:VKS.MHS.Elements.NodeMCU.NodeManager"/> class.
		/// </summary>
		NodeManager()
		{

		}

		~NodeManager()
		{
		}

		/// <summary>
		/// The field for instance exemplar.
		/// </summary>
		NodeManager FInstance;

		/// <summary>
		/// Gets the singletone instance of <see cref="NodeManager"/> class.
		/// </summary>
		/// <value>The singletone instance.</value>
		public NodeManager Instance
		{
			get
			{
				if (FInstance == null)
					FInstance = new NodeManager();
				return FInstance;
			}
		}
	}
}
