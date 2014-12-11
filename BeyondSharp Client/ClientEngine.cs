// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientEngine.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The client engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Client
{
    using BeyondSharp.Common;

    /// <summary>
    /// The client engine.
    /// </summary>
    public class ClientEngine : Engine<ClientEngineComponent>
    {
        /// <summary>
        /// Indicates that this engine is operating as a client.
        /// </summary>
        public override EngineSide Side
        {
            get
            {
                return EngineSide.Client;
            }
        }
    }
}