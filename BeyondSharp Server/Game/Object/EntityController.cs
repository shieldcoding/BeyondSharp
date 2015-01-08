#region Usings

using BeyondSharp.Common.Game.Object;

#endregion

namespace BeyondSharp.Server.Game.Object
{
    public class EntityController : IEntityController<Entity, EntityComponent>
    {
        #region IEntityController<Entity,EntityComponent> Members

        public Entity ControlledEntity { get; set; }

        #endregion
    }
}