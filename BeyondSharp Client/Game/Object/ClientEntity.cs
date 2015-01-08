#region Usings

using System;
using BeyondSharp.Common.Game.Object;

#endregion

namespace BeyondSharp.Client.Game.Object
{
    public class ClientEntity : IEntity<ClientEntity, ClientEntityComponent>
    {
        #region IEntity<ClientEntity,ClientEntityComponent> Members

        public string Description { get; set; }
        public Guid ID { get; internal set; }
        public string Name { get; set; }

        #endregion
    }
}