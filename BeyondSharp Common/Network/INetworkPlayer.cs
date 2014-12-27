#region Usings

using System;

#endregion

namespace BeyondSharp.Common.Network
{
    public interface INetworkPlayer
    {
        Guid HardwareToken { get; }
        Guid SessionToken { get; }
        string Username { get; }
    }
}