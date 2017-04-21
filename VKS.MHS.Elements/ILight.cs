using System;
namespace VKS.MHS.Elements
{
	/// <summary>
	/// Interface for generic light source
	/// </summary>
	public interface ILight: IElement
	{
		/// <summary>
		/// Switches the light on.
		/// </summary>
		void SwitchOn();

		/// <summary>
		/// Switches the light off.
		/// </summary>
		void SwitchOff();

		/// <summary>
		/// Gets or sets the brightness of light. For <see cref="VKS.MHS.Elements.ILight"/> 
		/// this property could return <c>0.00</c> for turned off light or <c>1.00</c> for turned
		/// on light.
		/// When set this property ignores any values ouside 0...1 range. All values greater than
		/// or equal to 0.5  rounded to 1, lesser than 0.5 - rounded to 0.
		/// </summary>
		/// <value>The brightness of light source.</value>
		double Brightness { get; set; }

        /// <summary>
        /// Gets the maximum power of light source in Watts or return <c>null</c> if this parameter is undefined.
        /// </summary>
        /// <value>
        /// The maximum power in Watts.
        /// </value>
        double? MaxPower { get; }

        /// <summary>
        /// Gets the maximum light intensity of light source in Lumens or return <c>null</c> if this parameter is undefined.
        /// </summary>
        /// <value>
        /// The maximum intensity in lumens.
        /// </value>
        double? MaxIntensity { get; }

        /// <summary>
        /// Gets the maximum luminosity of light source in candelas or return <c>null</c> if this parameter is undefined.
        /// </summary>
        /// <value>
        /// The maximum luminosity in candelas.
        /// </value>
        double? MaxLuminosity { get; }
	}
}
