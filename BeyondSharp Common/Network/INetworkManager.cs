// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INetworkManager.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The NetworkManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Network
{
    using Lidgren.Network;

    /// <summary>
    /// The NetworkManager interface.
    /// </summary>
    public interface INetworkManager : IEngineComponent
    {
        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        NetPeerConfiguration Configuration { get; }

        #endregion
    }
}