using System;

namespace VKS.MHS.Elements
{
    /// <summary>
    /// Structure for light color
    /// </summary>
    public struct LightColor
    {
        double FMax;
        double FMin;
        double FRed;
        double FGreen;
        double FBlue;

        /// <summary>
        /// The red component.
        /// </summary>
        public double Red
        {
            get { return FRed; }
            set
            {
                FRed = Math.Min(1.0, Math.Max(0.0, value));
                FMax = Math.Max(FMax, FRed);
                FMin = Math.Min(FMin, FRed);
            }
        }

        /// <summary>
        /// The green component.
        /// </summary>
        public double Green
        {
            get { return FGreen; }
            set
            {
                FGreen = Math.Min(1.0, Math.Max(0.0, value));
                FMax = Math.Max(FMax, FGreen);
                FMin = Math.Min(FMin, FGreen);
            }
        }

        /// <summary>
        /// The blue component.
        /// </summary>
        public double Blue
        {
            get { return FBlue; }
            set
            {
                FBlue = Math.Min(1.0, Math.Max(0.0, value));
                FMax = Math.Max(FMax, FBlue);
                FMin = Math.Min(FMin, FBlue);
            }
        }

        /// <summary>
        /// Sets the RGB from HSB.
        /// </summary>
        /// <param name="H">The hue component in interval [0, 360].</param>
        /// <param name="S">The saturation component in interval [0, 1].</param>
        /// <param name="B">The brightness component in interval [0, 1].</param>
        void SetRGBFromHSB(double H, double S, double B)
        {
            var _Chroma = B * S;

            var _HueSector = H / 60;

            var _X = _Chroma * (1 - Math.Abs(Math.IEEERemainder(_HueSector, 2) - 1));

            var _Level = B - _Chroma;

            var _Sector = Convert.ToInt32(Math.Ceiling(_HueSector));

            switch (_Sector)
            {
                case 1:
                    Red = _Level + _Chroma;
                    Green = _Level + _X;
                    Blue = 0;
                    break;
                case 2:
                    Red = _Level + _X;
                    Green = _Level + _Chroma;
                    Blue = 0;
                    break;
                case 3:
                    Red = 0;
                    Green = _Level + _Chroma;
                    Blue = _Level + _X;
                    break;
                case 4:
                    Red = 0;
                    Green = _Level + _X;
                    Blue = _Level + _Chroma;
                    break;
                case 5:
                    Red = _Level + _X;
                    Green = 0;
                    Blue = _Level + _Chroma;
                    break;
                case 6:
                    Red = _Level + _Chroma;
                    Green = 0;
                    Blue = _Level + _X;
                    break;
                default:
                    Red = _Level;
                    Green = _Level;
                    Blue = _Level;
                    return;
            }
        }

        /// <summary>
        /// Gets or sets the hue of color.
        /// </summary>
        /// <value>
        /// The hue value on hue circle as a degree from initial position 0 (pure red).
        /// </value>
        public double Hue
        {
            get
            {
                if ((FMax == FRed) && (FGreen >= FBlue))
                    return 60 * ((FGreen - FBlue) / (FMax - FMin));

                if ((FMax == FRed) && (FGreen < FBlue))
                    return 60 * ((FGreen - FBlue) / (FMax - FMin)) + 360;

                if (FMax == FGreen)
                    return 60 * ((FBlue - FRed) / (FMax - FMin)) + 120;

                if (FMax == FBlue)
                    return 60 * ((FRed - FGreen) / (FMax - FMin)) + 240;

                return 0;
            }

            set
            {
                var _CirclePos =
                    Math.IEEERemainder(value, 360);
                SetRGBFromHSB(_CirclePos, Saturation, Brightness);
            }
        }

        /// <summary>
        /// Gets or sets the brightness.
        /// </summary>
        /// <value>
        /// The brightness of light in interval [0 - black, 1 - white].
        /// </value>
        public double Brightness
        {
            get { return FMax; }
            set
            {
                var _Br = Math.Min(1.0, Math.Max(0.0, value));
                SetRGBFromHSB(Hue, Saturation, _Br);
            }
        }

        /// <summary>
        /// Gets or sets the saturation.
        /// </summary>
        /// <value>
        /// The saturation of light in interval [0 - grayscale, 1 - most saturated]
        /// </value>
        public double Saturation
        {
            get
            {
                return FMax != 0 ? (1 - FMin / FMax) : 0;
            }
            set
            {
                var _Sat = Math.Min(1.0, Math.Max(0.0, value));
                SetRGBFromHSB(Hue, _Sat, Brightness);
            }
        }

        

    }


}
