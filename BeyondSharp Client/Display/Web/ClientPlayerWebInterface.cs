using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awesomium.Core;
using BeyondSharp.Client.Network;
using BeyondSharp.Common.Display.Web;

namespace BeyondSharp.Client.Display.Web
{
    public class ClientPlayerWebInterface : IPlayerWebInterface<ClientPlayer>
    {
        public Guid Id { get; private set; }

        public ClientPlayer Player { get { return ClientProgram.Engine.NetworkManager.Player; } }

        public WebView View { get; private set; }

        internal ClientPlayerWebInterface(Guid id)
        {
            Id = id;
        }

        public void Initialize()
        {

        }
    }
}
