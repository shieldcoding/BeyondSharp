#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BeyondSharp.Common.Event;
using BeyondSharp.Common.Network;
using Lidgren.Network;

#endregion

namespace BeyondSharp.Server.Network
{
    public class ServerNetworkManager : ServerEngineComponent,
        INetworkManager<ServerNetworkManager, ServerNetworkProcessor, ServerNetworkDispatcher>
    {
        private readonly List<ServerPlayer> _players = new List<ServerPlayer>();

        public ServerNetworkManager(ServerEngine engine)
            : base(engine)
        {
            Dispatcher = new ServerNetworkDispatcher(this);
            Processor = new ServerNetworkProcessor(this);
        }

        public NetServer Server { get; private set; }

        #region INetworkManager<ServerNetworkManager,ServerNetworkProcessor,ServerNetworkDispatcher> Members

        public ServerNetworkDispatcher Dispatcher { get; private set; }
        public ServerNetworkProcessor Processor { get; private set; }
        public NetPeerConfiguration Configuration { get; private set; }

        #endregion

        /// <summary>
        ///     Retrieves all players currently connected to the server.
        /// </summary>
        /// <returns>A list containing all connected players.</returns>
        public IEnumerable<ServerPlayer> GetPlayers()
        {
            lock (_players)
                return _players.ToList();
        }

        public override void Initialize()
        {
            Configuration = new NetPeerConfiguration(NetworkConstants.Identifier);
            Configuration.LocalAddress = IPAddress.Parse(ServerProgram.Configuration.Network.Address);
            Configuration.Port = ServerProgram.Configuration.Network.Port;
            Configuration.MaximumConnections = ServerProgram.Configuration.Network.MaximumConnections;
            Configuration.SetMessageTypeEnabled(NetIncomingMessageType.ConnectionApproval, true);

            Server = new NetServer(Configuration);
            Server.Start();
        }

        public event EventHandler<ValueEventArgs<ServerPlayer>> PlayerConnected;
        public event EventHandler<ValueEventArgs<ServerPlayer>> PlayerDisconnected;
        
        protected override void OnUpdateFrame(TimeSpan elapsedTime)
        {
            NetIncomingMessage message = null;
            while ((message = Server.ReadMessage()) != null)
            {
                Processor.Process(message);
            }
        }

        internal ServerPlayer GetOrRegisterPlayer(NetConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException();
            }

            lock (_players)
            {
                if (!_players.Any(p => p.Connection == connection))
                {
                    RegisterPlayer(connection);
                }

                return _players.FirstOrDefault(p => p.Connection == connection);
            }
        }

        internal void OnPlayerConnected(ServerPlayer player)
        {
            if (PlayerConnected != null)
                PlayerConnected(this, new ValueEventArgs<ServerPlayer>(player));
        }

        internal void OnPlayerConnecting(ServerPlayer connection)
        {
        }

        internal void OnPlayerDisconnect(ServerPlayer player)
        {
            if (PlayerDisconnected != null)
                PlayerDisconnected(this, new ValueEventArgs<ServerPlayer>(player));
        }

        internal void RegisterPlayer(NetConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException();
            }

            lock (_players)
            {
                if (_players.Any(p => p.Connection == connection))
                {
                    throw new Exception();
                }

                var player = new ServerPlayer(connection);
                _players.Add(player);
            }
        }

        internal void UnregisterPlayer(NetConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException();
            }

            lock (_players)
            {
                var player = _players.FirstOrDefault(p => p.Connection == connection);

                if (player == null)
                {
                    return;
                }

                _players.Remove(player);
            }
        }
    }
}