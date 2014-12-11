// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerWorld.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server world.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.World
{
    using BeyondSharp.Common.World;

    /// <summary>
    /// The server world.
    /// </summary>
    public class ServerWorld : IWorld
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerWorld"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public ServerWorld(ServerWorldManager manager)
        {
            this.Manager = manager;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public ServerWorldManager Manager { get; private set; }

        #endregion
    }
}