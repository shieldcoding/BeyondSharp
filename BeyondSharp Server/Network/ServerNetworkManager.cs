using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Network
{
    public class ServerNetworkManager : ServerEngineComponent, INetworkManager
    {
        private List<ServerPlayer> _players = new List<ServerPlayer>();

        public NetServer Server { get; private set; }

        public NetPeerConfiguration Configuration { get; private set; }

        internal ServerNetworkDispatcher Dispatcher { get; private set; }

        internal ServerNetworkProcessor Processor { get; private set; }

        public ServerNetworkManager(ServerEngine engine)
            :base(engine)
        {
            Dispatcher = new ServerNetworkDispatcher(this);
            Processor = new ServerNetworkProcessor(this);
        }

        public override void Initialize()
        {
            Configuration = new NetPeerConfiguration(CommonNetworkConstants.IDENTIFIER);
            Configuration.LocalAddress = IPAddress.Parse(ServerProgram.Configuration.Network.Address);
            Configuration.Port = ServerProgram.Configuration.Network.Port;
            Configuration.MaximumConnections = ServerProgram.Configuration.Network.MaximumConnections;
            Configuration.SetMessageTypeEnabled(NetIncomingMessageType.ConnectionApproval, true);

            Server = new NetServer(Configuration);
            Server.Start();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            NetIncomingMessage message = null;
            while ((message = Server.ReadMessage()) != null)
                Processor.ProcessMessage(message);
        }

        /// <summary>
        /// Retrieves all players currently connected to the server.
        /// </summary>
        /// <returns>A list containing all connected players.</returns>
        public IEnumerable<ServerPlayer> GetPlayers()
        {
            lock (_players)
                return _players.ToList();
        }

        internal ServerPlayer GetOrRegisterPlayer(NetConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException();

            lock (_players)
            {
                if (!_players.Any(p => p.Connection == connection))
                    RegisterPlayer(connection);

                return _players.FirstOrDefault(p => p.Connection == connection);
            }
        }

        internal void RegisterPlayer(NetConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException();

            lock(_players)
            {
                if (_players.Any(p => p.Connection == connection))
                    throw new Exception();

                var player = new ServerPlayer(connection);
                _players.Add(player);
            }
        }

        internal void UnregisterPlayer(NetConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException();

            lock (_players)
            {
                var player = _players.FirstOrDefault(p => p.Connection == connection);

                if (player == null)
                    return;

                _players.Remove(player);
            }
        }
    
        internal void OnPlayerConnecting(ServerPlayer connection)
        {

        }

        internal void OnPlayerConnected(ServerPlayer connection)
        {
        }

        internal void OnPlayerDisconnect(ServerPlayer connection)
        {

        }
    }
}
