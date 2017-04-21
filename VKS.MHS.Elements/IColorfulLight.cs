using System;

namespace VKS.MHS.Elements
{
    /// <summary>
    /// Interface for lights that support hue/color change.
    /// </summary>
    public interface IColorfulLight: ILight
    {
        /// <summary>
        /// Fades the lights off from current color to black.
        /// </summary>
        void FadeOff();

        /// <summary>
        /// Fades the on from black to the last color.
        /// </summary>
        void FadeOn();

        /// <summary>
        /// Fades light from current color to a specified <paramref name="ATargetColor"/>.
        /// </summary>
        /// <param name="ATargetColor">A target color.</param>
        void FadeTo(LightColor ATargetColor);

        /// <summary>
        /// Gets or sets the color of light.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        LightColor Color { get; set; }

    }
}
