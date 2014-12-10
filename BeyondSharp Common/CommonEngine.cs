using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common
{
    /// <summary>
    /// Represents a sided instance of the BeyondSharp engine.
    /// </summary>
    public abstract class CommonEngine<EngineComponentType>
        where EngineComponentType : IEngineComponent
    {
        /// <summary>
        /// The sided (client/server) context of the engine.
        /// </summary>
        public EngineSide Side { get; protected set; }

        public List<EngineComponentType> Components { get; private set; }

        /// <summary>
        /// Retrieves all engine components owned by this engine.
        /// </summary>
        /// <returns>All engine components owned by the engine.</returns>
        public IEnumerable<EngineComponentType> GetComponents()
        { return Components; }

        public EngineComponentType GetComponent<FilteredEngineComponentType>() where FilteredEngineComponentType : EngineComponentType
        { return Components.OfType<FilteredEngineComponentType>().FirstOrDefault(); }

        public void RegisterComponent(EngineComponentType engineComponent)
        {
            if (engineComponent == null)
                throw new ArgumentNullException();

            if (Components.Contains(engineComponent))
                return;

            Components.Add(engineComponent);
        }

        public void UnregisterComponent(EngineComponentType engineComponent)
        {
            if (engineComponent == null)
                throw new ArgumentNullException();

            Components.Remove(engineComponent);
        }
    }
}
