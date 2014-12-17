namespace BeyondSharp.Common.Game.Object
{
    public interface IEntityComponent<TEntity, TEntityComponent>
        where TEntity : IEntity<TEntity, TEntityComponent>
        where TEntityComponent : IEntityComponent<TEntity, TEntityComponent>
    {
    }
}