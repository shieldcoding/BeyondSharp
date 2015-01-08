#region Usings

using Lidgren.Network;

#endregion

namespace BeyondSharp.Common.Network
{
    public interface INetworkManager<TNetworkManager, TNetworkProcessor, TNetworkDispatcher> : IEngineComponent
        where TNetworkManager : INetworkManager<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkProcessor : INetworkProcessor<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkDispatcher : INetworkDispatcher<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
    {
        NetPeerConfiguration Configuration { get; }
        TNetworkProcessor Processor { get; }
        TNetworkDispatcher Dispatcher { get; }
    }
}