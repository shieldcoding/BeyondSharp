using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client
{
    internal abstract class ClientEngineComponent : ICommonEngineComponent<ClientEngine>
    {
        public ClientEngine Engine { get; private set; }

        public ClientEngineComponent(ClientEngine engine)
        {
            Engine = engine;
        }
        
        public abstract void Initialize();

    }
}
