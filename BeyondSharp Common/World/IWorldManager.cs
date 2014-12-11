// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWorldManager.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The CommonWorldManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.World
{
    /// <summary>
    /// The CommonWorldManager interface.
    /// </summary>
    /// <typeparam name="TWorldType">
    /// The client or server implementation of the world held by the manager.
    /// </typeparam>
    public interface IWorldManager<TWorldType> : IEngineComponent
        where TWorldType : IWorld
    {
        #region Public Properties

        /// <summary>
        /// Gets the world.
        /// </summary>
        TWorldType World { get; }

        #endregion
    }
}