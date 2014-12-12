using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    public interface ICommonEntityController<EntityType, EntityComponentType>
        where EntityType : IEntity<EntityComponentType>
        where EntityComponentType : IEntityComponent
    {
        EntityType ControlledEntity { get; }   
    }
}
