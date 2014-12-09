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
    public class ClientPlayer : ICommonPlayer, ICommonEntityController<ClientEntity, ClientEntityComponent>
    {
        public string Username
        {
            get { throw new NotImplementedException(); }
        }

        public Guid AuthenticationToken
        {
            get { throw new NotImplementedException(); }
        }

        public Guid HardwareToken
        {
            get { throw new NotImplementedException(); }
        }

        public ClientEntity ControlledEntity
        {
            get { throw new NotImplementedException(); }
        }
    }
}
