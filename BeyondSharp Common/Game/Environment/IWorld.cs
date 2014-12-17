namespace BeyondSharp.Common.Game.Environment
{
    public interface IWorld <TWorldManager, TWorld, TWorldTile>
        where TWorldManager : IWorldManager<TWorldManager, TWorld, TWorldTile>
        where TWorld : IWorld<TWorldManager, TWorld, TWorldTile>
        where TWorldTile : IWorldTile<TWorldManager, TWorld, TWorldTile>
    {
    }
}