namespace BeyondSharp.Client.Game.Object
{
    using System;

    using BeyondSharp.Common.Game.Object;

    public class ClientEntity : IEntity<ClientEntity, ClientEntityComponent>
    {
        public Guid ID { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}