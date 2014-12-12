using BeyondSharp.Client.Entity;
using BeyondSharp.Common.Entity;
using BeyondSharp.Common.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Network
{
    public class ClientPlayer : IPlayer, ICommonEntityController<ClientEntity, ClientEntityComponent>
    {
        public string Username { get; internal set; }

        public Guid SessionToken { get; internal set; }

        public Guid HardwareToken { get; internal set; }

        public ClientEntity ControlledEntity
        {
            get;
            internal set;
        }
    }
}
