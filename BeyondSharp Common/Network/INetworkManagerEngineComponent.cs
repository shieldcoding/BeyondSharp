using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Network
{
    public interface INetworkManagerEngineComponent<EngineType> : IEngineComponent<EngineType>
        where EngineType : Engine
    {
        NetPeerConfiguration Configuration { get; }
    }
}
