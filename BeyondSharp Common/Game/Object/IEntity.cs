#region Usings

using System;

#endregion

namespace BeyondSharp.Common.Game.Object
{
    public interface IEntity<TEntity, TEntityComponent>
        where TEntity : IEntity<TEntity, TEntityComponent>
        where TEntityComponent : IEntityComponent<TEntity, TEntityComponent>
    {
        string Description { get; }
        Guid ID { get; }
        string Name { get; }
    }
}