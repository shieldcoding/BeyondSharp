// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerNetworkManager.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server network manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using BeyondSharp.Common.Network;

    using Lidgren.Network;

    /// <summary>
    /// The server network manager.
    /// </summary>
    public class ServerNetworkManager : ServerEngineComponent, INetworkManager
    {
        #region Fields

        /// <summary>
        /// The players.
        /// </summary>
        private List<ServerPlayer> players = new List<ServerPlayer>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerNetworkManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        public ServerNetworkManager(ServerEngine engine)
            : base(engine)
        {
            this.Dispatcher = new ServerNetworkDispatcher(this);
            this.Processor = new ServerNetworkProcessor(this);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public NetPeerConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets the server.
        /// </summary>
        public NetServer Server { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the dispatcher.
        /// </summary>
        internal ServerNetworkDispatcher Dispatcher { get; private set; }

        /// <summary>
        /// Gets the processor.
        /// </summary>
        internal ServerNetworkProcessor Processor { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Retrieves all players currently connected to the server.
        /// </summary>
        /// <returns>A list containing all connected players.</returns>
        public IEnumerable<ServerPlayer> GetPlayers()
        {
            lock (this.players)
            {
                return this.players.ToList();
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        public override void Initialize()
        {
            this.Configuration = new NetPeerConfiguration(CommonNetworkConstants.Identifier);
            this.Configuration.LocalAddress = IPAddress.Parse(ServerProgram.Configuration.Network.Address);
            this.Configuration.Port = ServerProgram.Configuration.Network.Port;
            this.Configuration.MaximumConnections = ServerProgram.Configuration.Network.MaximumConnections;
            this.Configuration.SetMessageTypeEnabled(NetIncomingMessageType.ConnectionApproval, true);

            this.Server = new NetServer(this.Configuration);
            this.Server.Start();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="elapsedTime">
        /// The elapsed time.
        /// </param>
        public override void Update(TimeSpan elapsedTime)
        {
            NetIncomingMessage message = null;
            while ((message = this.Server.ReadMessage()) != null)
            {
                this.Processor.ProcessMessage(message);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get or register player.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        /// <returns>
        /// The <see cref="ServerPlayer"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        internal ServerPlayer GetOrRegisterPlayer(NetConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException();
            }

            lock (this.players)
            {
                if (!this.players.Any(p => p.Connection == connection))
                {
                    this.RegisterPlayer(connection);
                }

                return this.players.FirstOrDefault(p => p.Connection == connection);
            }
        }

        /// <summary>
        /// Raises an event when the server first establishes a network connection with a client.
        /// </summary>
        /// <param name="connection">
        /// The client connection that has just opened.
        /// </param>
        internal void OnClientConnecting(NetConnection connection)
        {
        }

        /// <summary>
        /// Raises an event when a client has disconnected from the server.
        /// </summary>
        /// <param name="connection">
        /// The client connection that has just closed.
        /// </param>
        internal void OnClientDisconnect(NetConnection connection)
        {
        }

        /// <summary>
        /// Raises an event when the player has successfully connected and authenticated with the server.
        /// </summary>
        /// <param name="player">
        /// The player that has completed the connection process.
        /// </param>
        internal void OnPlayerConnected(ServerPlayer player)
        {
        }

        /// <summary>
        /// Creates a server-sided player object using the supplied connection and registers it with the network manager.
        /// </summary>
        /// <param name="connection">
        /// The network connection to be used.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to register a network connection with the network manager, but received a null reference.
        /// </exception>
        /// <exception cref="Exception">
        /// Tried to register a network connection with the network manager, but the supplied connection is already registered via another player.
        /// </exception>
        internal void RegisterPlayer(NetConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException();
            }

            lock (this.players)
            {
                if (this.players.Any(p => p.Connection == connection))
                {
                    throw new Exception();
                }

                var player = new ServerPlayer(connection);
                this.players.Add(player);
            }
        }

        /// <summary>
        /// The unregister player.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        internal void UnregisterPlayer(NetConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException();
            }

            lock (this.players)
            {
                var player = this.players.FirstOrDefault(p => p.Connection == connection);

                if (player == null)
                {
                    return;
                }

                this.players.Remove(player);
            }
        }

        #endregion
    }
}