// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEngineComponent.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The EngineComponent interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common
{
    using System;

    /// <summary>
    /// The EngineComponent interface.
    /// </summary>
    public interface IEngineComponent
    {
        #region Public Methods and Operators

        /// <summary>
        /// The initialize.
        /// </summary>
        void Initialize();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="elapsedTime">
        /// The elapsed time.
        /// </param>
        void Update(TimeSpan elapsedTime);

        #endregion
    }
}