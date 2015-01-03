using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeyondSharp.Common.Display.Web;
using BeyondSharp.Server.Network;

namespace BeyondSharp.Server.Display.Web
{
    public class ServerPlayerWebInterface : IPlayerWebInterface<ServerPlayer>
    {
        public Guid Id { get; private set; }
        public ServerPlayer Player { get; private set; }
    
        internal ServerPlayerWebInterface(ServerPlayer player)
        {
            Player = player;
        }
    }
}
