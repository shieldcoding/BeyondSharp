// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The Entity interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Entity
{
    using System;

    /// <summary>
    /// The Entity interface.
    /// </summary>
    /// <typeparam name="TEntityType">
    /// The type of entity.
    /// </typeparam>
    /// <typeparam name="TEntityComponentType">
    /// The type of entity component this entity contains.
    /// </typeparam>
    public interface IEntity<TEntityType, TEntityComponentType>
        where TEntityType : IEntity<TEntityType, TEntityComponentType>
        where TEntityComponentType : IEntityComponent<TEntityType, TEntityComponentType>
    {
        #region Public Properties

        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        Guid ID { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        #endregion
    }
}