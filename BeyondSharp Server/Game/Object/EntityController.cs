namespace BeyondSharp.Server.Game.Object
{
    using BeyondSharp.Common.Game.Object;

    public class EntityController : IEntityController<Entity, EntityComponent>
    {
        public Entity ControlledEntity { get; set; }
    }
}