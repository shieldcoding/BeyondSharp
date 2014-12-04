using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Network
{
    public enum NetworkProtocol
    {
        /// <summary>
        /// Used for the connection handshake.
        /// 
        /// <see cref="BeyondSharp.Client.Network.ClientNetworkManager"/>
        /// </summary>
        Connect,
        Disconnect,
        WorldData,
        WorldTimeSync,

        /// <summary>
        /// Sent by the server to instruct the client to allocate an entity with the specified ID.
        /// 
        /// Parameters:
        /// (Guid) ID
        /// </summary>
        EntityRegister,

        /// <summary>
        /// Send by the server to instruct the client to unallocate an entity with the specified ID.
        /// 
        /// Parameters:
        /// (Guid) ID
        /// </summary>
        EntityUnregister,
        EntityData,
        EntityMove
    }
}
