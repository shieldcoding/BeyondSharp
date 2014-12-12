// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityController.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The IEntityController interface specifies a shared interface between client and server for representing control over an entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Entity
{
    /// <summary>
    /// The CommonEntityController interface.
    /// </summary>
    /// <typeparam name="EntityType">
    /// The type of entity this entity controller controls.
    /// </typeparam>
    /// <typeparam name="EntityComponentType">
    /// The type of entity component contained by entities.
    /// </typeparam>
    public interface IEntityController<EntityType, EntityComponentType>
        where EntityType : IEntity<EntityComponentType> where EntityComponentType : IEntityComponent
    {
        #region Public Properties

        /// <summary>
        /// Gets the controlled entity.
        /// </summary>
        EntityType ControlledEntity { get; }

        #endregion
    }
}