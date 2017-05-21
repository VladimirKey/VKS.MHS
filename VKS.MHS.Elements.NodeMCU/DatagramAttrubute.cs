using System;
namespace VKS.MHS.Elements.NodeMCU
{

	/// <summary>
	/// Datagram attribute.
	/// This attribute specifies datagram identifier for <see cref="Datagrams.NodeDatagram"/> class ancestors.
	/// </summary>
	[System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public sealed class DatagramAttribute : Attribute
	{
		readonly Guid FDatagramId;

		/// <summary>
		/// Gets the datagram identifier.
		/// </summary>
		/// <value>The datagram identifier.</value>
		public Guid DatagramId
		{
			get { return FDatagramId; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:VKS.MHS.Elements.NodeMCU.DatagramAttribute"/> class.
		/// </summary>
		/// <param name="ADatagramId">A target datagram identifier.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="ADatagramId"/> parameter
		/// is unset or empty/whitespaced string.</exception>
		public DatagramAttribute(string ADatagramId)
		{
			if (string.IsNullOrWhiteSpace(ADatagramId))
				throw new ArgumentNullException(nameof(ADatagramId));
			
			FDatagramId = Guid.Parse(ADatagramId);
		}
	}
}
