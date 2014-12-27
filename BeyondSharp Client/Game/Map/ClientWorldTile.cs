namespace BeyondSharp.Client.Game.Map
{
    using System;
    using System.Linq;

    using BeyondSharp.Common.Game.Map;

    public class ClientWorldTile : IWorldTile<ClientWorldManager, ClientWorld, ClientWorldTile>
    {
        public ClientWorld World
        {
            get { throw new NotImplementedException(); }
        }

        public int X
        {
            get { throw new NotImplementedException(); }
        }

        public int Y
        {
            get { throw new NotImplementedException(); }
        }
    }
}