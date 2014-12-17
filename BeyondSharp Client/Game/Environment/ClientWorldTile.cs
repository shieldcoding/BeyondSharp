namespace BeyondSharp.Client.Game.Environment
{
    using System;
    using System.Linq;

    using BeyondSharp.Common.Game.Environment;

    public class ClientWorldTile : IWorldTile<ClientWorldManager, ClientWorld, ClientWorldTile>
    {
        public ClientWorld World
        {
            get { throw new NotImplementedException(); }
        }
    }
}
