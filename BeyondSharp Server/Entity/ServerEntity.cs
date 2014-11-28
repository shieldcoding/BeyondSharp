using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Entity
{
    public class ServerEntity : ICommonEntity<ServerEntityComponent>
    {
        public Guid ID { get; internal set; }

        public ServerEntityManager Manager { get; internal set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
