﻿namespace BeyondSharp.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Represents a sided instance of the BeyondSharp engine.
    /// </summary>
    public abstract class Engine<TEngineComponent>
        where TEngineComponent : IEngineComponent
    {
        /// <summary>
        ///     The sided (client/server) context of the engine.
        /// </summary>
        public EngineSide Side { get; protected set; }

        public List<TEngineComponent> Components { get; private set; }

        /// <summary>
        ///     Retrieves all engine components owned by this engine.
        /// </summary>
        /// <returns>All engine components owned by the engine.</returns>
        public IEnumerable<TEngineComponent> GetComponents()
        {
            return Components;
        }

        public void RegisterComponent(TEngineComponent engineComponent)
        {
            if (engineComponent == null)
            {
                throw new ArgumentNullException();
            }

            if (Components.Contains(engineComponent))
            {
                return;
            }

            Components.Add(engineComponent);
        }

        public void UnregisterComponent(TEngineComponent engineComponent)
        {
            if (engineComponent == null)
            {
                throw new ArgumentNullException();
            }

            Components.Remove(engineComponent);
        }
    }
}