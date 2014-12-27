#region Usings

using BeyondSharp.Common.Network;
using Lidgren.Network;

#endregion

namespace BeyondSharp.Client.Network
{
    internal class ClientNetworkProcessor
    {
        public ClientNetworkProcessor(ClientNetworkManager manager)
        {
            Manager = manager;
        }

        internal NetIncomingMessage CurrentMessage { get; private set; }
        internal ClientNetworkManager Manager { get; private set; }

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

        private void ProcessConnectedStatusMessage()
        {
            Manager.Dispatcher.DispatchConnectRequest();
        }

        #region Connection message processing

        private void ProcessConnectionRequest()
        {
            Manager.Dispatcher.DispatchConnectionAuthenticate();
        }

        #endregion

        private void ProcessDataMessage()
        {
            var protocol = (NetworkProtocol) CurrentMessage.ReadInt16();

            switch (protocol)
            {
                case NetworkProtocol.ConnectionRequest:
                    ProcessConnectionRequest();
                    return;
                case NetworkProtocol.EntityRegister:
                    ProcessEntityRegister();
                    return;
                case NetworkProtocol.EntityUnregister:
                    ProcessEntityUnregister();
                    return;
            }
        }

        private void ProcessDisconnectedStatusMessage()
        {
        }

        private void ProcessStatusChanged()
        {
            var status = (NetConnectionStatus) CurrentMessage.ReadByte();

            switch (status)
            {
                case NetConnectionStatus.Connected:
                    ProcessConnectedStatusMessage();
                    return;
                case NetConnectionStatus.Disconnected:
                    ProcessDisconnectedStatusMessage();
                    return;
            }
        }

        #region World message processing

        private void ProcessWorldData()
        {
        }

        #endregion

        #region Entity message processing

        private void ProcessEntityRegister()
        {
        }

        private void ProcessEntityUnregister()
        {
        }

        #endregion
    }
}