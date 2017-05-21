using System;
using Newtonsoft.Json;

namespace VKS.MHS.Elements.NodeMCU.Datagrams
{
	/// <summary>
	/// Abstraction layer for all command json.
	/// </summary>
	public abstract class NodeDatagram
	{
		/// <summary>
		/// Gets or sets the version of protocol.
		/// </summary>
		/// <value>The version of protocol.</value>
		[JsonRequired, JsonProperty("version")]
		public double Version
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the IP address of sender.
		/// </summary>
		/// <value>The IP address of sender.</value>
		[JsonRequired,JsonProperty("ip")]
		public string IPAddress
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the sender port.
		/// </summary>
		/// <value>The sender's port.</value>
		[JsonProperty("port")]
		public int Port
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the identifier of element.
		/// </summary>
		/// <value>The identifier of sender element.</value>
		[JsonRequired, JsonProperty("id")]
		public Guid Identifier
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the datagram type identifier.
		/// </summary>
		/// <value>The datagram type identifier. Every datagram type has its
		/// own identifier set in class definition.</value>
		[JsonRequired, JsonProperty("commandId")]
		public Guid DatagramTypeId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the class identifier of target element.
		/// </summary>
		/// <value>The class identifier of target element.</value>
		[JsonRequired, JsonProperty("classId")]
		public string ClassId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether target element is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		[JsonProperty("enabled")]
		public bool Enabled
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether target element is faulty.
		/// </summary>
		/// <value><c>true</c> if it is faulty; otherwise, <c>false</c>.</value>
		[JsonProperty("faulty")]
		public bool IsFaulty
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the fault message.
		/// </summary>
		/// <value>The fault message.</value>
		[JsonProperty("faultMessage")]
		public string FaultMessage
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the fault code.
		/// </summary>
		/// <value>The fault code.</value>
		[JsonProperty("faultCode")]
		public int? FaultCode
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the location of target element.
		/// </summary>
		/// <value>The location of target element.</value>
		[JsonProperty("location")]
		public string Location
		{
			get;
			set;
		}
	}

	/// <summary>
	/// Stub abstract class for ingoing (recieved from nodes) datagrams.
	/// </summary>
	public abstract class IngoingDatagram : NodeDatagram
	{
		/// <summary>
		/// Gets or sets the response code from node.
		/// </summary>
		/// <value>The response code.</value>
		public int ResponseCode
		{
			get;
			set;
		} 
	}

	/// <summary>
	/// Stub abstract class for outgoing (sent to nodes) datagrams.
	/// </summary>
	public abstract class OutgoingDatagram : NodeDatagram
	{
		/// <summary>
		/// Gets or sets the username for authorization purposes.
		/// </summary>
		/// <value>The username.</value>
		[JsonProperty("user")]
		public string Username
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the password for authorization purposes.
		/// </summary>
		/// <value>The password in plain text.</value> 
		/// <remarks>Yep, I know that plaintext passwords are suck, but it depends on
		/// hw possibilities to process cryptography.</remarks>
		[JsonProperty("pwd")]
		public string Password
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the auth token instead of <see cref="Username"/> and <see cref="Password"/>.
		/// </summary>
		/// <value>The auth token.</value>
		[JsonProperty("token")]
		public string AuthToken
		{
			get;
			set;
		}
	}

}
