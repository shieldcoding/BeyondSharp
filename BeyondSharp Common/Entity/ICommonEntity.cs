using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    public interface ICommonEntity
    {
        Guid ID { get; }
        
        string Name { get; }

        string Description { get; }
    }
}
