#region Usings

using BeyondSharp.Common.Game.Object;

#endregion

namespace BeyondSharp.Server.Game.Object
{
    public class EntityController : IEntityController<Entity, EntityComponent>
    {
        public Entity ControlledEntity { get; set; }
    }
}