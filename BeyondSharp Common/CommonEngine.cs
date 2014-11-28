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
        where EngineComponentType : ICommonEngineComponent
    {
        protected List<EngineComponentType> _components = null;

        /// <summary>
        /// The sided (client/server) context of the engine.
        /// </summary>
        public EngineSide Side { get; protected set; }

        /// <summary>
        /// Retrieves all engine components owned by this engine.
        /// </summary>
        /// <returns>All engine components owned by the engine.</returns>
        public IEnumerable<EngineComponentType> GetComponents()
        { return _components; }

        public EngineComponentType GetComponent<FilteredEngineComponentType>() where FilteredEngineComponentType : EngineComponentType
        { return _components.OfType<FilteredEngineComponentType>().FirstOrDefault(); }

        public void RegisterComponent(EngineComponentType engineComponent)
        {
            if (engineComponent == null)
                throw new ArgumentNullException();

            if (_components.Contains(engineComponent))
                return;

            _components.Add(engineComponent);
        }

        public void UnregisterComponent(EngineComponentType engineComponent)
        {
            if (engineComponent == null)
                throw new ArgumentNullException();

            _components.Remove(engineComponent);
        }
    }
}
