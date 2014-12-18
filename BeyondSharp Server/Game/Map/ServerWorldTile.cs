namespace BeyondSharp.Server.Game.Map
{
    using System;
    using System.Linq;

    using BeyondSharp.Common.Game.Map;

    public class ServerWorldTile : IWorldTile<ServerWorldManager, ServerWorld, ServerWorldTile>
    {
        public ServerWorld World { get; internal set; }

        public int X { get; internal set; }

        public int Y { get; internal set; }

        public ServerWorldTile(ServerWorld serverWorld, int x, int y)
        {
            
        }
    }
}