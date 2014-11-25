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
    public abstract class FrameworkEngine
    {
        /// <summary>
        /// The sided (client/server) context of the engine.
        /// </summary>
        public FrameworkEngineSide Side { get; protected set; }
    }
}
