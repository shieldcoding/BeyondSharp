using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client
{
    internal class ClientEngineComponent : IEngineComponent<ClientEngine>
    {
        public ClientEngine Engine { get; private set; }

        public ClientEngineComponent(ClientEngine engine)
        {
            Engine = engine;
        }
    }
}
