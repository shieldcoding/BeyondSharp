namespace BeyondSharp.Server.Entity
{
    using BeyondSharp.Common.Entity;

    public class ServerEntityController : ICommonEntityController<ServerEntity, ServerEntityComponent>
    {
        public ServerEntity ControlledEntity { get; set; }
    }
}