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
    /// <typeparam name="EntityComponentType">
    /// The type of entity component this entity contains.
    /// </typeparam>
    public interface IEntity<EntityComponentType>
        where EntityComponentType : IEntityComponent
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