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
	}
}
