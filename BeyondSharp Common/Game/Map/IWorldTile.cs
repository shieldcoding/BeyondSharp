namespace BeyondSharp.Common.Game.Map
{
    public interface IWorldTile<TWorldManager, TWorld, TWorldTile>
        where TWorldManager : IWorldManager<TWorldManager, TWorld, TWorldTile>
        where TWorld : IWorld<TWorldManager, TWorld, TWorldTile>
        where TWorldTile : IWorldTile<TWorldManager, TWorld, TWorldTile>
    {
        TWorld World { get; }
        int X { get; }
        int Y { get; }
    }
}