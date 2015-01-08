using Lidgren.Network;

namespace BeyondSharp.Common.Network
{
    public interface INetworkProcessor<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkManager : INetworkManager<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkProcessor : INetworkProcessor<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkDispatcher : INetworkDispatcher<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
    {
        TNetworkManager Manager { get; }
        NetIncomingMessage CurrentMessage { get; }
        void Process(NetIncomingMessage message);
    }
}