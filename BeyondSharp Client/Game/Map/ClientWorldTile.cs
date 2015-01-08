#region Usings

using System;
using BeyondSharp.Common.Game.Map;

#endregion

namespace BeyondSharp.Client.Game.Map
{
    public class ClientWorldTile : IWorldTile<ClientWorldManager, ClientWorld, ClientWorldTile>
    {
        #region IWorldTile<ClientWorldManager,ClientWorld,ClientWorldTile> Members

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

        #endregion
    }
}