using System;
using Awesomium.Core;
using BeyondSharp.Client.Network;
using BeyondSharp.Common.Display.Web;

namespace BeyondSharp.Client.Display.Web
{
    public class ClientPlayerWebInterface : IPlayerWebInterface<ClientPlayer>
    {
        internal ClientPlayerWebInterface(Guid id)
        {
            Id = id;
        }

        public WebView View { get; private set; }

        public void Initialize()
        {
        }

        #region IPlayerWebInterface<ClientPlayer> Members

        public Guid Id { get; private set; }

        public ClientPlayer Player
        {
            get { return ClientProgram.Engine.NetworkManager.Player; }
        }

        #endregion
    }
}