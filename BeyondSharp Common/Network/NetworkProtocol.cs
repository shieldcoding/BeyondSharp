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
        /// Sent by the client to initiate a connection with the server.
        /// 
        /// <see cref="BeyondSharp.Client.Network.ClientNetworkManager"/>
        /// 
        /// Parameters
        /// (Double) Protocol Version
        /// </summary>
        ConnectRequest,

        /// <summary>
        /// Sent by the server in response to the client's connection request, and is then sent back by the client with authentication details.
        /// 
        /// Parameters (Client)
        /// (String) Username
        /// (Guid) Token
        /// </summary>
        ConnectAuth,

        /// <summary>
        /// Sent by the server when the client is clear to connect, and is then sent back by the client to notify the server that the client is ready.
        /// </summary>
        ConnectAccept,

        /// <summary>
        /// Sent by either side to notify the other that it is terminating the connection gracefully.
        /// 
        /// Parameters
        /// (Boolean) Reason Included
        /// (String) Reason [Optional]
        /// </summary>
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
