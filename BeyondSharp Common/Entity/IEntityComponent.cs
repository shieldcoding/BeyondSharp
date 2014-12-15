namespace BeyondSharp.Common.Entity
{
    public interface IEntityComponent<TEntity, TEntityComponent>
        where TEntity : IEntity<TEntity, TEntityComponent>
        where TEntityComponent : IEntityComponent<TEntity, TEntityComponent>
    {
    }
}