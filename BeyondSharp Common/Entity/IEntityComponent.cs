// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityComponent.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The EntityComponent interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Entity
{
    /// <summary>
    /// The EntityComponent interface.
    /// </summary>
    /// <typeparam name="TEntityType">
    /// The type of entity.
    /// </typeparam>
    /// <typeparam name="TEntityComponentType">
    /// The type of entity component.
    /// </typeparam>
    public interface IEntityComponent<TEntityType, TEntityComponentType>
        where TEntityType : IEntity<TEntityType, TEntityComponentType>
        where TEntityComponentType : IEntityComponent<TEntityType, TEntityComponentType>
    {
    }
}