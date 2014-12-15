namespace BeyondSharp.Server.Entity
{
    using BeyondSharp.Common.Entity;

    public class ServerEntityController : IEntityController<ServerEntity, ServerEntityComponent>
    {
        public ServerEntity ControlledEntity { get; set; }
    }
}