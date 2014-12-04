using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Entity
{
    public class ClientEntityManager : ClientEngineComponent, ICommonEntityManager<ClientEntity, ClientEntityComponent>
    {
        private object _lock = null;
        private List<ClientEntity> _entityList = null;
        private Dictionary<Guid, ClientEntity> _entityLookup = null;

        internal ClientEntityManager(ClientEngine engine)
            : base(engine)
        {
            _lock = new object();
            _entityList = new List<ClientEntity>();
            _entityLookup = new Dictionary<Guid, ClientEntity>();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        public ClientEntity GetEntity(Guid id)
        {
            if (id == default(Guid))
                return null;

            lock (_lock)
            {
                if (_entityLookup.ContainsKey(id))
                    return _entityLookup[id];
                else
                    return null;
            }
        }

        public IEnumerable<FilteredType> GetEntities<FilteredType>() where FilteredType : ClientEntity
        { return _entityList.OfType<FilteredType>(); }

        public Guid RegisterEntity(ClientEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            lock (_lock)
            {
                if (!_entityList.Contains(entity))
                    _entityList.Add(entity);

                if (!_entityLookup.ContainsKey(entity.ID))
                    _entityLookup.Add(entity.ID, entity);
            }

            return entity.ID;
        }

        public void UnregisterEntity(ClientEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            lock (_lock)
            {
                _entityList.Remove(entity);
                _entityLookup.Remove(entity.ID);
            }
        }
    }
}
