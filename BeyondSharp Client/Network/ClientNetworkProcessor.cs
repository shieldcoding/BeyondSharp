using BeyondSharp.Common.Network;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkProcessor
    {
        internal ClientNetworkManager Manager { get; private set; }

        internal NetIncomingMessage CurrentMessage { get; private set; }

        public ClientNetworkProcessor(ClientNetworkManager manager)
        {
            Manager = manager;
        }

        internal void Process(NetIncomingMessage message)
        {
            CurrentMessage = message;

            switch (CurrentMessage.MessageType)
            {
                case NetIncomingMessageType.StatusChanged:
                    ProcessStatusChanged();
                    break;
                case NetIncomingMessageType.Data:
                    ProcessDataMessage();
                    break;
            }
        }

        private void ProcessStatusChanged()
        {

        }

        private void ProcessDataMessage()
        {
            var protocol = (NetworkProtocol)CurrentMessage.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectionRequest:
                    ProcessConnectRequest();
                    return;
            }
        }

        private void ProcessConnectRequest()
        { Manager.Dispatcher.DispatchConnectionAuthenticate(); }
    }
}
