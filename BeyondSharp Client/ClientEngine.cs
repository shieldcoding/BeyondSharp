namespace BeyondSharp.Client
{
    using BeyondSharp.Common;

    public class ClientEngine : Engine<ClientEngineComponent>
    {
        internal ClientEngine()
        {
            Side = EngineSide.Client;
        }
    }
}