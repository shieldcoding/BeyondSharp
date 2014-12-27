#region Usings

using Lidgren.Network;

#endregion

namespace BeyondSharp.Common.Network
{
    public interface INetworkManager : IEngineComponent
    {
        NetPeerConfiguration Configuration { get; }
    }
}