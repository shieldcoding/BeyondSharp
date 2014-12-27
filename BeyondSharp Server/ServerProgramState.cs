namespace BeyondSharp.Server
{
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