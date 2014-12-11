// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerEntityController.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server entity controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Entity
{
    using BeyondSharp.Common.Entity;

    /// <summary>
    /// The server entity controller.
    /// </summary>
    public class ServerEntityController : IEntityController<ServerEntity, ServerEntityComponent>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the controlled entity.
        /// </summary>
        public ServerEntity ControlledEntity { get; set; }

        #endregion
    }
}