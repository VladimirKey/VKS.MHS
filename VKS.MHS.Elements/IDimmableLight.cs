using System;
namespace VKS.MHS.Elements
{
	/// <summary>
	/// Interface for light with dimmer capability.
	/// </summary>
	public interface IDimmableLight: ILight
	{
		/// <summary>
		/// Steps the light brighness up.
		/// </summary>
		void StepUp();

		/// <summary>
		/// Steps the light brightness down.
		/// </summary>
		void StepDown();

		/// <summary>
		/// Gets or sets the step of brightness change (delta) as
		/// percent. The value should be within (0; 1) range. 
		/// </summary>
		/// <value>The step of dimmer.</value>
		double Step { get; set; }

		/// <summary>
		/// Gets or sets the brightness of light. For <see cref="VKS.MHS.Elements.ILight"/> 
		/// this property could return <c>0.00</c> for turned off light or <c>1.00</c> for turned
		/// on light.
		/// When set this property ignores any values ouside [0; 1] range. Value within this range
		/// depicts the brightness of light in percent. 
		/// </summary>
		/// <value>The brightness of light source.</value>
		new double Brightness { get; set; }
	}
}
