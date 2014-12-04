using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Entity
{
    public class ServerEntityManager : ServerEngineComponent, ICommonEntityManager<ServerEntity, ServerEntityComponent>
    {
        private object _lock = null;
        private List<ServerEntity> _entityList = null;
        private Dictionary<Guid, ServerEntity> _entityIDLookup = null;

        public ServerEntityManager(ServerEngine engine)
            :base(engine)
        {
            _lock = new object();
            _entityList = new List<ServerEntity>();
            _entityIDLookup = new Dictionary<Guid, ServerEntity>();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        public ServerEntity GetEntity(Guid id)
        {
            if (id == default(Guid))
                return null;

            if (_entityIDLookup.ContainsKey(id))
                return _entityIDLookup[id];
            else
                return null;
        }

        public IEnumerable<FilteredEntityType> GetEntities<FilteredEntityType>() where FilteredEntityType : ServerEntity
        { return _entityList.OfType<FilteredEntityType>(); }

        public Guid RegisterEntity(ServerEntity entity)
        {
            lock (_lock)
            {
                if (_entityList.Contains(entity))
                {
                    if (entity.ID == default(Guid))
                        return default(Guid);
                }
                else
                {
                    entity.ID = Guid.NewGuid();
                    entity.Manager = this;

                    _entityList.Add(entity);
                    _entityIDLookup.Add(entity.ID, entity);
                }
            }

            return entity.ID;
        }

        public void UnregisterEntity(ServerEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            lock (_lock)
            {
                _entityList.Remove(entity);
                _entityIDLookup.Remove(entity.ID);
            }
        }

    }
}
