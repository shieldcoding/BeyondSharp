namespace BeyondSharp.Server.Network
{
    using System;

    using BeyondSharp.Common.Network;
    using BeyondSharp.Server.Entity;

    using Lidgren.Network;

    public class ServerPlayer : ServerEntityController, IPlayer
    {
        internal ServerPlayer(NetConnection connection)
        {
            Connection = connection;
        }

        public bool IsAuthenticated { get; internal set; }

        internal NetConnection Connection { get; private set; }

        public string Username { get; internal set; }

        public Guid SessionToken { get; internal set; }

        public Guid HardwareToken { get; internal set; }

        public void Disconnect(string reason = null)
        {
            if (Connection == null)
            {
                return;
            }

            Connection.Disconnect(reason);
        }
    }
}