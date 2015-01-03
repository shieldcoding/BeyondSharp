namespace BeyondSharp.Common.Network
{
    public interface INetworkDispatcher<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkManager : INetworkManager<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkProcessor : INetworkProcessor<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
        where TNetworkDispatcher : INetworkDispatcher<TNetworkManager, TNetworkProcessor, TNetworkDispatcher>
    {
        TNetworkManager Manager { get; }
    }
}