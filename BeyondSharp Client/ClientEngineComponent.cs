using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client
{
    public abstract class ClientEngineComponent : ICommonEngineComponent
    {
        public ClientEngine Engine { get; private set; }

        public ClientEngineComponent(ClientEngine engine)
        {
            Engine = engine;
        }
        
        public abstract void Initialize();

        public abstract void Update(TimeSpan elapsedTime);
    }
}
