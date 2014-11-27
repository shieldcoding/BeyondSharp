using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Entity
{
    public class ServerEntityManager : ServerEngineComponent, ICommonEntityManager<ServerEngine, ServerEntity>
    {
        private List<ServerEntity> _entities = new List<ServerEntity>();
        private Dictionary<Guid, ServerEntity> _entityLookup = new Dictionary<Guid, ServerEntity>();

        public ServerEntityManager(ServerEngine engine)
            :base(engine)
        {

        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public ServerEntity GetEntity(Guid id)
        {
            if (_entityLookup.ContainsKey(id))
                return _entityLookup[id];
            else
                return null;
        }

        public IEnumerable<FilteredType> GetEntities<FilteredType>() where FilteredType : ServerEntity
        {
            throw new NotImplementedException();
        }

        public void RegisterEntity(ServerEntity entity)
        {
        }

        public void UnregisterEntity(ServerEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
