using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Entity
{
    public class ClientEntity : ICommonEntity<ClientEntityComponent>
    {
        public Guid ID { get; internal set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
