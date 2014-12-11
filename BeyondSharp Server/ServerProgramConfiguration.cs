// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerProgramConfiguration.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server program configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server
{
    using System.ComponentModel;
    using System.Net;

    using BeyondSharp.Common.Network;

    using Newtonsoft.Json;

    /// <summary>
    /// The server program configuration.
    /// </summary>
    public class ServerProgramConfiguration
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerProgramConfiguration"/> class.
        /// </summary>
        public ServerProgramConfiguration()
        {
            this.Runtime = new RuntimeConfiguration();
            this.Network = new NetworkConfiguration();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the network.
        /// </summary>
        public NetworkConfiguration Network { get; private set; }

        /// <summary>
        /// Gets the runtime.
        /// </summary>
        public RuntimeConfiguration Runtime { get; private set; }

        #endregion

        /// <summary>
        /// The network configuration.
        /// </summary>
        public class NetworkConfiguration
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="NetworkConfiguration"/> class.
            /// </summary>
            public NetworkConfiguration()
            {
                this.Address = IPAddress.Any.ToString();
                this.Port = CommonNetworkConstants.DefaultPort;
                this.MaximumConnections = CommonNetworkConstants.DefaultMaximumConnections;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the address.
            /// </summary>
            [JsonProperty]
            public string Address { get; private set; }

            /// <summary>
            /// Gets the maximum connections.
            /// </summary>
            [JsonProperty]
            [DefaultValue(CommonNetworkConstants.DefaultMaximumConnections)]
            public int MaximumConnections { get; private set; }

            /// <summary>
            /// Gets the port.
            /// </summary>
            [JsonProperty]
            [DefaultValue(CommonNetworkConstants.DefaultPort)]
            public int Port { get; private set; }

            #endregion
        }

        /// <summary>
        /// The runtime configuration.
        /// </summary>
        public class RuntimeConfiguration
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="RuntimeConfiguration"/> class.
            /// </summary>
            public RuntimeConfiguration()
            {
                this.Path = ServerConstants.DefaultRuntimePath;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the path.
            /// </summary>
            [JsonProperty]
            [DefaultValue(ServerConstants.DefaultRuntimePath)]
            public string Path { get; private set; }

            #endregion
        }
    }
}