namespace BeyondSharp.Client.Network
{
    using System;

    using BeyondSharp.Client.Entity;
    using BeyondSharp.Common.Entity;
    using BeyondSharp.Common.Network;

    public class ClientPlayer : IPlayer, IEntityController<ClientEntity, ClientEntityComponent>
    {
        public ClientEntity ControlledEntity { get; internal set; }

        public string Username { get; internal set; }

        public Guid SessionToken { get; internal set; }

        public Guid HardwareToken { get; internal set; }
    }
}