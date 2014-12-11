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
    /// <typeparam name="TEntityType">
    /// The type of entity this entity controller controls.
    /// </typeparam>
    /// <typeparam name="TEntityComponentType">
    /// The type of entity component contained by entities.
    /// </typeparam>
    public interface IEntityController<TEntityType, TEntityComponentType>
        where TEntityType : IEntity<TEntityType, TEntityComponentType>
        where TEntityComponentType : IEntityComponent<TEntityType, TEntityComponentType>
    {
        #region Public Properties

        /// <summary>
        /// Gets the controlled entity.
        /// </summary>
        TEntityType ControlledEntity { get; }

        #endregion
    }
}