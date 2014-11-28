using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client
{
    public class ClientEngine : CommonEngine<ClientEngineComponent>
    {
        internal ClientEngine()
        {
            Side = EngineSide.Client;
        }
    }
}
