﻿#region Usings

using System;
using BeyondSharp.Common.Game.Map;

#endregion

namespace BeyondSharp.Client.Game.Map
{
    public class ClientWorld : IWorld<ClientWorldManager, ClientWorld, ClientWorldTile>
    {
        internal ClientWorld(ClientWorldManager manager)
        {
            Manager = manager;
        }

        #region IWorld<ClientWorldManager,ClientWorld,ClientWorldTile> Members

        public ClientWorldTile GetTile(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Height { get; private set; }
        public ClientWorldManager Manager { get; private set; }
        public int Width { get; private set; }

        #endregion
    }
}