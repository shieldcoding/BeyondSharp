// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientEngineComponent.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client engine component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client
{
    using System;

    using BeyondSharp.Common;

    /// <summary>
    /// The client engine component.
    /// </summary>
    public abstract class ClientEngineComponent : IEngineComponent
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientEngineComponent"/> class.
        /// </summary>
        /// <param name="engine">
        /// The engine.
        /// </param>
        public ClientEngineComponent(ClientEngine engine)
        {
            this.Engine = engine;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the engine.
        /// </summary>
        public ClientEngine Engine { get; private set; }

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