namespace BeyondSharp.Server.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BeyondSharp.Common.Entity;

    public class ServerEntityManager : ServerEngineComponent, IEntityManager<ServerEntity, ServerEntityComponent>
    {
        private readonly Dictionary<Guid, ServerEntity> entities = new Dictionary<Guid, ServerEntity>();

        public ServerEntityManager(ServerEngine engine)
            : base(engine)
        {
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

            return entities.ContainsKey(id) ? entities[id] : null;
        }

        public IEnumerable<ServerEntity> GetEntities()
        {
            return entities.Values.ToList();
        }

        public Guid RegisterEntity(ServerEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            
            if (entities.ContainsKey(entity.ID))
                return entity.ID;

            entity.ID = Guid.NewGuid();
            entity.Manager = this;

            entities.Add(entity.ID, entity);

            return entity.ID;
        }

        public void UnregisterEntity(ServerEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (!entities.Remove(entity.ID))
                return;

            entity.ID = default(Guid);
            entity.Manager = null;
        }
    }
}