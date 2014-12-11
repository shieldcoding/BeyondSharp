// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientWorldManager.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client world manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client.World
{
    using System;

    using BeyondSharp.Common.World;

    /// <summary>
    /// The client world manager.
    /// </summary>
    public class ClientWorldManager : ClientEngineComponent, IWorldManager<ClientWorld>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientWorldManager"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        public ClientWorldManager(ClientEngine engine)
            : base(engine)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the world.
        /// </summary>
        public ClientWorld World { get; private set; }

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