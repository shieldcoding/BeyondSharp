namespace BeyondSharp.Common.Entity
{
    public interface ICommonEntityController<EntityType, EntityComponentType>
        where EntityType : IEntity<EntityComponentType>
        where EntityComponentType : IEntityComponent
    {
        EntityType ControlledEntity { get; }
    }
}