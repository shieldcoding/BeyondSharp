namespace BeyondSharp.Common.Entity
{
    public interface IEntityController<TEntity, TEntityComponent>
        where TEntity : IEntity<TEntity, TEntityComponent>
        where TEntityComponent : IEntityComponent<TEntity, TEntityComponent>
    {
        TEntity ControlledEntity { get; }
    }
}