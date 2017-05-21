using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace VKS.MHS.Elements.NodeMCU
{
	/// <summary>
	/// Abstract class for all NodeMCU-based elements.
	/// </summary>
	public abstract class NodeElement: IElement
	{

		private const double CurrentVersion = 1.0;

		protected const int ERROR_INVALID_JSON = 10100;

		/// <summary>
		/// The default node port.
		/// </summary>
		public static int DefaultNodePort = 54045;

		/// <summary>
		/// Gets or sets the ip address and port of NodeMCU board.
		/// </summary>
		/// <value>The address and port of NodeMCU board in network.</value>
		/// <remarks>This parameter could be shared among many elements. I.e. one
		/// NodeMCU board combines several elements. In this case different
		/// elements should have different <see cref="Id"/> but the same 
		/// <see cref="Address"/>.</remarks>
		public IPEndPoint Address
		{
			get;
			internal set;
		}

		/// <summary>
		/// Gets the class identifier.
		/// </summary>
		/// <value>The class identifier.</value>
		public string ClassId
		{
			get; private set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:VKS.MHS.Elements.NodeMCU.NodeElement"/> is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		public bool Enabled
		{
			get; set;
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:VKS.MHS.Elements.NodeMCU.NodeElement"/> is faulty.
		/// </summary>
		/// <value><c>true</c> if faulty; otherwise, <c>false</c>.</value>
		public bool Faulty
		{
			get; protected set;
		}

		public string FaultMessage
		{
			get; protected set;
		}

		public int FaultCode
		{
			get; protected set;
		}

		/// <summary>
		/// Gets or sets the identifier of element.
		/// </summary>
		/// <value>The identifier.</value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the location of NodeMCU element.
		/// </summary>
		/// <value>The location of NodeMCU board.</value>
		public string Location
		{
			get; set;
		}

		/// <summary>
		/// Gets the battery level.
		/// </summary>
		/// <value>The battery level.</value>
		public double? BatteryLevel
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Inits the async.
		/// </summary>
		/// <returns>The async.</returns>
		public async Task InitAsync()
		{
		}

		public async Task ShutdownAsync()
		{
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init()
		{
			//
		}

		/// <summary>
		/// Shutdown this instance.
		/// </summary>
		public void Shutdown()
		{
			//
		}
	}
}
