using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common
{
    /// <summary>
    /// Represents a sided instance of the BeyondSharp engine.
    /// </summary>
    public interface ICommonEngine
    {
        /// <summary>
        /// The sided (client/server) context of the engine.
        /// </summary>
        EngineSide Side { get; }
    }
}
