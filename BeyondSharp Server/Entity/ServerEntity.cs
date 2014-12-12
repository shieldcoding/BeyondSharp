namespace BeyondSharp.Server.Entity
{
    using System;

    using BeyondSharp.Common.Entity;

    public class ServerEntity : IEntity<ServerEntityComponent>
    {
        public ServerEntityManager Manager { get; internal set; }

        public Guid ID { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}