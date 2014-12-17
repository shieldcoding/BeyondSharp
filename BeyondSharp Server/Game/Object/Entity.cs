namespace BeyondSharp.Server.Game.Object
{
    using System;

    using BeyondSharp.Common.Game.Object;

    public class Entity : IEntity<Entity, EntityComponent>
    {
        public EntityManager Manager { get; internal set; }

        public Guid ID { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}