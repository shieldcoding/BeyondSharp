#region Usings

using System;
using BeyondSharp.Common.Game.Map;
using Newtonsoft.Json;

#endregion

namespace BeyondSharp.Server.Game.Map
{
    public class ServerWorld : IWorld<ServerWorldManager, ServerWorld, ServerWorldTile>
    {
        private ServerWorldTile[,] tiles;

        public ServerWorldTile GetTile(int x, int y)
        {
            if (x < 0 || x >= Width)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException();
            }

            return tiles[x, y];
        }

        public int Height { get; private set; }

        [JsonIgnore]
        public ServerWorldManager Manager { get; private set; }

        public int Width { get; private set; }

        /// <summary>
        ///     Initializes the world from the given parameters and allocates the tile array.
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        internal void Initialize(ServerWorldManager manager, int width, int height)
        {
            Manager = manager;
            Width = width;
            Height = height;

            tiles = new ServerWorldTile[Width, Height];
        }
    }
}