namespace BeyondSharp.Client.Entity
{
    using System;

    using BeyondSharp.Common.Entity;

    public class ClientEntity : IEntity<ClientEntityComponent>
    {
        public Guid ID { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}