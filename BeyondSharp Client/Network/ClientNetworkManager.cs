﻿using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkManager : ClientEngineComponent, ICommonNetworkManager
    {
        public NetClient Client { get; private set; }

        public NetConnection Connection { get; private set; }

        public NetPeerConfiguration Configuration { get; private set; }

        public bool IsConnected { get; private set; }

        public ClientNetworkDispatcher Dispatcher { get; private set; }

        public ClientNetworkProcessor Processor { get; private set; }

        public ClientNetworkManager(ClientEngine engine)
            :base(engine)
        {
            Dispatcher = new ClientNetworkDispatcher(this);
            Processor = new ClientNetworkProcessor(this);
        }

        public override void Initialize()
        {
            Client = new NetClient(Configuration);
        }
        
        public void Connect(string host, int port = NetworkConstants.DEFAULT_PORT)
        {
            if (string.IsNullOrWhiteSpace(host))
                throw new ArgumentNullException();

            Connection = Client.Connect(host, port);
            IsConnected = true;
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
            }
        }
    }
}
