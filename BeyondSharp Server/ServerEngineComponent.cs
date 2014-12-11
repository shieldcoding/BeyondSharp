// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerEngineComponent.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server engine component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server
{
    using System;

    using BeyondSharp.Common;

    /// <summary>
    /// The server engine component.
    /// </summary>
    public abstract class ServerEngineComponent : IEngineComponent
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEngineComponent"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        public ServerEngineComponent(ServerEngine engine)
        {
            this.Engine = engine;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the engine.
        /// </summary>
        public ServerEngine Engine { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The initialize.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="elapsedTime">
        /// The elapsed time.
        /// </param>
        public abstract void Update(TimeSpan elapsedTime);

        #endregion
    }
}