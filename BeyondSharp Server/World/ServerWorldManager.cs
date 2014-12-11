// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerWorldManager.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server world manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.World
{
    using System;

    using BeyondSharp.Common.World;

    /// <summary>
    /// The server world manager.
    /// </summary>
    public class ServerWorldManager : ServerEngineComponent, IWorldManager<ServerWorld>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerWorldManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        public ServerWorldManager(ServerEngine engine)
            : base(engine)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the world.
        /// </summary>
        public ServerWorld World { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="elapsedTime">
        /// The elapsed time.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}