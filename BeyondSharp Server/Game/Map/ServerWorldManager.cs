namespace BeyondSharp.Server.Game.Map
{
    using System;
    using System.IO;

    using BeyondSharp.Common.Game.Map;

    public class ServerWorldManager : ServerEngineComponent, IWorldManager<ServerWorldManager, ServerWorld, ServerWorldTile>
    {
        public ServerWorldManager(ServerEngine engine)
            : base(engine)
        {
        }


        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        public ServerWorld LoadWorldFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            var data = File.ReadAllText(path);
            return LoadWorld(data);
        }

        public ServerWorld LoadWorld(string data)
        {
            throw new NotImplementedException();
        }

        public ServerWorld CreateWorld(int width, int height)
        {
            var world = new ServerWorld();
            world.Initialize(this, width, height);

            return world;
        }
    }
}