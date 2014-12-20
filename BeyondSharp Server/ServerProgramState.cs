namespace BeyondSharp.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public enum ServerProgramState
    {
        New = 0,
        Initializing = 1,
        Initialized = 2,
        Running = 3,
        Stopping = 4,
        Stopped = 5
    }
}
