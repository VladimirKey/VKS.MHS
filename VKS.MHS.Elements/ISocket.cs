using System;

namespace VKS.MHS.Elements
{
    /// <summary>
    /// Interface for simple socket.
    /// </summary>
    public interface ISocket: IElement
    {
        /// <summary>
        /// Gets the maximum voltage of socket in Volts.
        /// </summary>
        /// <value>
        /// The maximum voltage of socket.
        /// </value>
        double MaxVoltage { get; }

        /// <summary>
        /// Gets the voltage of socket.
        /// </summary>
        /// <value>
        /// The voltage of socket in Volts or <c>null</c> if this parameter not supported.
        /// </value>
        double? Voltage { get; }

        /// <summary>
        /// Gets the maximum current of socket in Amperes.
        /// </summary>
        /// <value>
        /// The maximum current of socket in Amperes.
        /// </value>
        double MaxCurrent { get; }

        /// <summary>
        /// Gets the current in socket.
        /// </summary>
        /// <value>
        /// The current in socket in amperes or <c>null</c> if this parameter not supported.
        /// </value>
        double? Current { get; }

        /// <summary>
        /// Gets the maximum power in Watts.
        /// </summary>
        /// <value>
        /// The maximum power of socket in watts.
        /// </value>
        double MaxPower { get; }

        /// <summary>
        /// Gets the power in socket.
        /// </summary>
        /// <value>
        /// The power in socket in Watts or <c>null</c> if this parameter not supported.
        /// </value>
        double? Power { get; }

        /// <summary>
        /// Gets a value indicating whether some appliances is connected this socket.
        /// </summary>
        /// <value>
        /// <c>true</c> if this socket is busy; otherwise, <c>false</c>.
        /// </value>
        bool IsConnected { get; }

    }
}
