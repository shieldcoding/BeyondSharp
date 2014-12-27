namespace BeyondSharp.Common.Game.Map
{
    public interface IWorld<TWorldManager, TWorld, TWorldTile>
        where TWorldManager : IWorldManager<TWorldManager, TWorld, TWorldTile>
        where TWorld : IWorld<TWorldManager, TWorld, TWorldTile>
        where TWorldTile : IWorldTile<TWorldManager, TWorld, TWorldTile>
    {
        int Height { get; }
        TWorldManager Manager { get; }
        int Width { get; }
        TWorldTile GetTile(int x, int y);
    }
}