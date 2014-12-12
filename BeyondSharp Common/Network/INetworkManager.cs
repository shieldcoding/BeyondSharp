namespace BeyondSharp.Common.Network
{
    using Lidgren.Network;

    public interface INetworkManager : IEngineComponent
    {
        NetPeerConfiguration Configuration { get; }
    }
}