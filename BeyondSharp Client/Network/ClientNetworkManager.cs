#region Usings

using System;
using BeyondSharp.Common.Network;
using Lidgren.Network;

#endregion

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkManager : ClientEngineComponent,
        INetworkManager<ClientNetworkManager, ClientNetworkProcessor, ClientNetworkDispatcher>
    {
        public ClientNetworkManager(ClientEngine engine)
            : base(engine)
        {
            Dispatcher = new ClientNetworkDispatcher(this);
            Processor = new ClientNetworkProcessor(this);
        }

        public NetClient Client { get; private set; }
        public NetConnection Connection { get; private set; }
        public ClientNetworkDispatcher Dispatcher { get; private set; }
        public bool IsConnected { get; private set; }
        public ClientPlayer Player { get; private set; }
        public ClientNetworkProcessor Processor { get; private set; }

        public override void Initialize()
        {
            Client = new NetClient(Configuration);
        }

        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        public NetPeerConfiguration Configuration { get; private set; }

        /// <summary>
        ///     Initiates a new connection to the specified host on the optionally specified port (defaulting if needed).
        /// </summary>
        /// <param name="host">The host to be connected to.</param>
        /// <param name="port">The port with which to connect to the host on.</param>
        public void Connect(string host, int port = NetworkConstants.DefaultPort)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentNullException();
            }

            Connection = Client.Connect(host, port);
            IsConnected = true;

            Dispatcher.DispatchConnectRequest();
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
            }
        }
    }
}