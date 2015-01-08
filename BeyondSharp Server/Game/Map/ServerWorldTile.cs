#region Usings

using System.IO;
using BeyondSharp.Common.Game.Map;

#endregion

namespace BeyondSharp.Server.Game.Map
{
    public class ServerWorldTile : IWorldTile<ServerWorldManager, ServerWorld, ServerWorldTile>
    {
        public ServerWorldTile(ServerWorld serverWorld, int x, int y)
        {
        }

        #region IWorldTile<ServerWorldManager,ServerWorld,ServerWorldTile> Members

        public ServerWorld World { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }

        #endregion

        public void Serialize(MemoryStream stream)
        {
        }
    }
}