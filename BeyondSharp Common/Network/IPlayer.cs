// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The Player interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Network
{
    using System;

    /// <summary>
    /// The Player interface.
    /// </summary>
    public interface IPlayer
    {
        #region Public Properties

        /// <summary>
        /// Gets the hardware token.
        /// </summary>
        Guid HardwareToken { get; }

        /// <summary>
        /// Gets the session token.
        /// </summary>
        Guid SessionToken { get; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        string Username { get; }

        #endregion
    }
}