namespace BeyondSharp.Common.Network
{
    using System;

    public interface INetworkPlayer
    {
        string Username { get; }

        Guid SessionToken { get; }

        Guid HardwareToken { get; }
    }
}