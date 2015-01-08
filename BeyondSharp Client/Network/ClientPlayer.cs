#region Usings

using System;
using BeyondSharp.Client.Game.Object;
using BeyondSharp.Common.Game.Object;
using BeyondSharp.Common.Network;

#endregion

namespace BeyondSharp.Client.Network
{
    public class ClientPlayer : INetworkPlayer, IEntityController<ClientEntity, ClientEntityComponent>
    {
        #region IEntityController<ClientEntity,ClientEntityComponent> Members

        public ClientEntity ControlledEntity { get; internal set; }

        #endregion

        #region INetworkPlayer Members

        public Guid HardwareToken { get; internal set; }
        public Guid SessionToken { get; internal set; }
        public string Username { get; internal set; }

        #endregion
    }
}