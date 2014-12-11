// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Engine.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   Represents a sided instance of the BeyondSharp engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a sided instance of the BeyondSharp engine.
    /// </summary>
    /// <typeparam name="TEngineComponentType">
    /// The type of engine component that this engine contains.
    /// </typeparam>
    public abstract class Engine<TEngineComponentType>
        where TEngineComponentType : IEngineComponent
    {
        #region Public Properties

        /// <summary>
        /// Gets the components.
        /// </summary>
        public List<TEngineComponentType> Components { get; private set; }

        /// <summary>
        /// Gets an indicator as to whether the engine is operating as a client or server.
        /// </summary>
        public abstract EngineSide Side { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Retrieves the first engine component of the supplied type that is registered with the engine.
        /// </summary>
        /// <typeparam name="TFilteredEngineComponentType">
        /// The type of engine component to retrieve.
        /// </typeparam>
        /// <returns>
        /// The engine component of the supplied type that is registered with the engine, or null if there is none.
        /// </returns>
        public TEngineComponentType GetComponent<TFilteredEngineComponentType>()
            where TFilteredEngineComponentType : TEngineComponentType
        {
            return this.Components.OfType<TFilteredEngineComponentType>().FirstOrDefault();
        }

        /// <summary>
        /// Retrieves all engine components owned by this engine.
        /// </summary>
        /// <returns>An enumeration of all engine components registered with the engine.</returns>
        public IEnumerable<TEngineComponentType> GetComponents()
        {
            return this.Components.ToList();
        }

        /// <summary>
        /// Registers an engine component with the engine.
        /// </summary>
        /// <param name="engineComponent">
        /// The engine component to be registered with the engine.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to register a component with the engine, but received a null reference.
        /// </exception>
        public void RegisterComponent(TEngineComponentType engineComponent)
        {
            if (engineComponent.Equals(null))
            {
                throw new ArgumentNullException();
            }

            if (this.Components.Contains(engineComponent))
            {
                return;
            }

            this.Components.Add(engineComponent);
        }

        /// <summary>
        /// Unregisters an engine component from the engine.
        /// </summary>
        /// <param name="engineComponent">
        /// The engine component to be unregistered from the engine.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to unregister a component from the engine, but received a null reference.
        /// </exception>
        public void UnregisterComponent(TEngineComponentType engineComponent)
        {
            if (engineComponent.Equals(null))
            {
                throw new ArgumentNullException();
            }

            this.Components.Remove(engineComponent);
        }

        #endregion
    }
}