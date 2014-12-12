namespace BeyondSharp.Common.Network
{
    using System;

    public interface IPlayer
    {
        string Username { get; }

        Guid SessionToken { get; }

        Guid HardwareToken { get; }
    }
}