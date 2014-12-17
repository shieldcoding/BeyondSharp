namespace BeyondSharp.Server.Game.Environment
{
    using System;
    using System.Linq;

    using BeyondSharp.Common.Game.Environment;

    public class WorldTile : IWorldTile<WorldManager, World, WorldTile>
    {
        public World World
        {
            get { throw new NotImplementedException(); }
        }
    }
}
