namespace BeyondSharp.Common.Network
{
    public enum NetworkProtocol
    {
        /// <summary>
        ///     Sent by the client to initiate a connection with the server.
        ///     <see cref="BeyondSharp.Client.Network.ClientNetworkManager" />
        ///     Parameters
        ///     (Double) Protocol Version
        /// </summary>
        ConnectionRequest,

        /// <summary>
        ///     Sent by the server in response to the client's connection request, and is then sent back by the client with
        ///     authentication details.
        ///     - Parameters (Client)
        ///     (String) Username
        ///     (Guid) AuthenticationToken
        ///     (Guid) HardwareToken
        /// </summary>
        ConnectionAuthRequest,

        /// <summary>
        ///     Sent by the server to notify the client that it's authentication details have been rejected.
        /// </summary>
        ConnectionAuthRejected,

        /// <summary>
        ///     Sent by the server to notify the client that it's authentication details have been accepted.
        /// </summary>
        ConnectionAuthAccepted,


        /// <summary>
        ///     Sent by the server when the client is clear to connect, and is then sent back by the client to notify the server
        ///     that the client is ready.
        /// </summary>
        ConnectionAccepted,

        /// <summary>
        ///     Sent by the server to the client to update the observed data of the current world the client is on.
        /// </summary>
        WorldData,

        WorldTimeSync,

        /// <summary>
        ///     Sent by the server to instruct the client to allocate an entity with the specified ID.
        ///     Parameters:
        ///     (Guid)      Entity ID
        /// </summary>
        EntityRegister,

        /// <summary>
        ///     Sent by the server to instruct the client to unallocate an entity with the specified ID.
        ///     Parameters:
        ///     (Guid)      Entity ID
        /// </summary>
        EntityUnregister,

        EntityData,

        EntityMove,

        /// <summary>
        ///     Sent by the server to instruct the client to create a web interface with the supplied ID and the optionally
        ///     supplied width and height.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (Integer)   Interface Width             [Optional]
        ///     (Integer)   Interface Height            [Optional]
        /// </summary>
        WebInterfaceCreate,

        /// <summary>
        ///     Sent by the server to instruct the client to destroy the web interface with the supplied ID.
        ///     Parameters:
        ///     (Guid)      Interface ID
        /// </summary>
        WebInterfaceDestroy,

        /// <summary>
        ///     Sent by the server to instruct the client to load the supplied HTML data into the web interface.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (String)    Raw HTML/Javascript
        /// </summary>
        WebInterfaceLoad,

        /// <summary>
        ///     Sent by the server to instruct the client to return a set of values with the corresponding names as JSON-Serialized
        ///     objects.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (Integer)   Javascript Object Count
        ///     (String)    Javascript Object Value     [Multiple]
        /// </summary>
        WebInterfaceGetValuesRequest,

        /// <summary>
        ///     Sent by the client to supply the server with the request JSON-serialized objects.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (Integer)   Javascript Object Count
        ///     (String)    Javascript Object Name      [Multiple]
        /// </summary>
        WebInterfaceGetValuesResponse,

        /// <summary>
        ///     Sent by the server to instruct the client to set the values of the javascript variables with the specified names to
        ///     the supplied JSON-Serialized objects.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (Integer)   Javascript Object Count
        ///     (String)    Javascript Object Value     [Multiple]
        /// </summary>
        WebInterfaceSetValuesRequest,

        /// <summary>
        ///     Sent by the client to notify the server that the requested values have been set.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (Integer)   Javascript Object Count
        ///     (String)    Javascript Object Name      [Multiple]
        /// </summary>
        WebInterfaceSetValuesResponse,

        /// <summary>
        ///     Sent by the server to instruct the client to execute the javascript method with the specified name.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (String)    Javascript Method Name
        /// </summary>
        WebInterfaceExecuteMethodRequest,

        /// <summary>
        ///     Sent by the client to notify the server that the requested method has been executed.
        ///     Parameters:
        ///     (Guid)      Interface ID
        ///     (String)    Javascript Method Name
        /// </summary>
        WebInterfaceExecuteMethodResponse
    }
}