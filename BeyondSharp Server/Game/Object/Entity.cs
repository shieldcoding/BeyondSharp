#region Usings

using System;
using BeyondSharp.Common.Game.Object;

#endregion

namespace BeyondSharp.Server.Game.Object
{
    public class Entity : IEntity<Entity, EntityComponent>
    {
        public EntityManager Manager { get; internal set; }

        #region IEntity<Entity,EntityComponent> Members

        public string Description { get; set; }
        public Guid ID { get; internal set; }
        public string Name { get; set; }

        #endregion
    }
}