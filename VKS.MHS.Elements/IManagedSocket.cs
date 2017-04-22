using System;

namespace VKS.MHS.Elements
{
    /// <summary>
    /// Interface for socket that supports
    /// remote control.
    /// </summary>
    interface IManagedSocket : ISocket
    {
        /// <summary>
        /// Turns the current on.
        /// </summary>
        void PowerOn();

        /// <summary>
        /// Turns the current off.
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Gets or sets a value indicating whether this socket is powered on.
        /// </summary>
        /// <value>
        /// <c>true</c> if this socket is powered on; otherwise, <c>false</c>.
        /// </value>
        bool IsPoweredOn { get; set; }
    }
}
