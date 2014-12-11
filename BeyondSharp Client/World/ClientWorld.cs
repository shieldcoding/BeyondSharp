// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientWorld.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client world.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.World
{
    using BeyondSharp.Common.World;

    /// <summary>
    /// The client world.
    /// </summary>
    public class ClientWorld : IWorld
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientWorld"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        internal ClientWorld(ClientWorldManager manager)
        {
            this.Manager = manager;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public ClientWorldManager Manager { get; private set; }

        #endregion
    }
}