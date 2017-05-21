using System;

namespace VKS.MHS.Elements
{
	/// <summary>
	/// Interface for generic element props and methods
	/// </summary>
	public interface IElement
	{
		/// <summary>
		/// Gets the identifier of element within system.
		/// </summary>
		/// <value>The identifier of element as <see cref="System.Guid"/> value.</value>
		Guid Id { get; }

		/// <summary>
		/// Gets the class identifier.
		/// </summary>
		/// <value>The class identifier of element.</value>
		string ClassId { get; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:VKS.MHS.Elements.IElement"/> is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		bool Enabled { get; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:VKS.MHS.Elements.IElement"/> is faulty.
		/// </summary>
		/// <value><c>true</c> if element is faulty; otherwise, <c>false</c>.</value>
		bool Faulty { get; }

        /// <summary>
        /// Gets or sets the location of element within network.
        /// </summary>
        /// <value>
        /// The location of element.
        /// </value>
        string Location { get; set; }

		/// <summary>
		/// Gets the battery level in percents.
		/// </summary>
		/// <value>The battery level in percents.
		/// <list type="unordered">
		/// <item><c>  0 %</c> - for discharged battery,</item>
		/// <item><c>100 %</c> - for fully charged battery,</item>
		/// <item><c> null</c> - for devices without batteries / autonomous capabilities.</item>
		/// </list>
		/// </value>
		double? BatteryLevel { get; }

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		void Init();

		/// <summary>
		/// Shutdowns this instance.
		/// </summary>
		void Shutdown();
	}
}
