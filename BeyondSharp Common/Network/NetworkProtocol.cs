// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkProtocol.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The network protocol.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Network
{
    /// <summary>
    /// The network protocol.
    /// </summary>
    public enum NetworkProtocol
    {
        /// <summary>
        /// Sent by the client to initiate a connection with the server.
        /// - Parameters (Client-only)
        /// (Double) Protocol Version
        /// </summary>
        ConnectionRequest, 

        /// <summary>
        /// Sent by the server in response to the client's connection request, and is then sent back by the client with authentication details.
        /// <para>
        /// Parameters (Client)
        /// (String) Username
        /// (String) Session token GUID as a string.
        /// (String) Hardware token GUID as a string.
        /// </para>
        /// </summary>
        ConnectionAuthenticate, 

        /// <summary>
        /// Sent by the server when the client is clear to connect, and is then sent back by the client to notify the server that the client is ready.
        /// </summary>
        ConnectAccept, 

        /// <summary>
        /// The world data.
        /// </summary>
        WorldData, 

        /// <summary>
        /// The world time sync.
        /// </summary>
        WorldTimeSync, 

        /// <summary>
        /// Sent by the server to instruct the client to allocate an entity with the specified ID.
        /// <para>
        /// Parameters (Server)
        /// (String) Entity ID as a string.
        /// </para>
        /// </summary>
        EntityRegister, 

        /// <summary>
        /// Send by the server to instruct the client to unregister and remove an entity with the specified ID.
        /// <para>
        /// Parameters (Server)
        /// (String) Entity ID as a string.
        /// </para>
        /// </summary>
        EntityUnregister, 

        /// <summary>
        /// The entity data.
        /// </summary>
        EntityData, 

        /// <summary>
        /// The entity move.
        /// </summary>
        EntityMove
    }
}