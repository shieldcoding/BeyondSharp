#region Usings



#endregion

namespace BeyondSharp.Common
{
    /// <summary>
    ///     Represents a sided instance of the BeyondSharp engine.
    /// </summary>
    public interface IEngine<TEngineComponent>
        where TEngineComponent : IEngineComponent
    {
        /// <summary>
        ///     The sided (client/server) context of the engine.
        /// </summary>
        EngineSide Side { get; }
    }
}