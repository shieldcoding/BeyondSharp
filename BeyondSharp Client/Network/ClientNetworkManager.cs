// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientNetworkManager.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client network manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.Network
{
    using System;

    using BeyondSharp.Common.Network;

    using Lidgren.Network;

    /// <summary>
    /// The client network manager.
    /// </summary>
    internal class ClientNetworkManager : ClientEngineComponent, INetworkManager
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientNetworkManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        public ClientNetworkManager(ClientEngine engine)
            : base(engine)
        {
            this.Dispatcher = new ClientNetworkDispatcher(this);
            this.Processor = new ClientNetworkProcessor(this);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the client.
        /// </summary>
        public NetClient Client { get; private set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public NetPeerConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        public NetConnection Connection { get; private set; }

        /// <summary>
        /// Gets the dispatcher.
        /// </summary>
        public ClientNetworkDispatcher Dispatcher { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is connected.
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Gets the player.
        /// </summary>
        public ClientPlayer Player { get; private set; }

        /// <summary>
        /// Gets the processor.
        /// </summary>
        public ClientNetworkProcessor Processor { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Initiates a new connection to the specified host on the optionally specified port (defaulting if needed).
        /// </summary>
        /// <param name="host">
        /// The host to be connected to.
        /// </param>
        /// <param name="port">
        /// The port with which to connect to the host on.
        /// </param>
        public void Connect(string host, int port = CommonNetworkConstants.DefaultPort)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentNullException();
            }

            this.Connection = this.Client.Connect(host, port);
            this.IsConnected = true;

            this.Dispatcher.DispatchConnectRequest();
        }

        /// <summary>
        /// The disconnect.
        /// </summary>
        public void Disconnect()
        {
            if (this.IsConnected)
            {
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        public override void Initialize()
        {
            this.Client = new NetClient(this.Configuration);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="elapsedTime">
        /// The elapsed time.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}