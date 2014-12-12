namespace BeyondSharp.Client.Network
{
    using BeyondSharp.Common.Network;

    using Lidgren.Network;

    internal class ClientNetworkProcessor
    {
        public ClientNetworkProcessor(ClientNetworkManager manager)
        {
            Manager = manager;
        }

        internal ClientNetworkManager Manager { get; private set; }

        internal NetIncomingMessage CurrentMessage { get; private set; }

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
        {
            Manager.Dispatcher.DispatchConnectionAuthenticate();
        }
    }
}