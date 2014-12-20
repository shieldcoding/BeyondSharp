namespace BeyondSharp.Server.Game.Object
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BeyondSharp.Common.Game.Object;

    public class EntityManager : ServerEngineComponent, IEntityManager<Entity, EntityComponent>
    {
        private readonly Dictionary<Guid, Entity> entities = new Dictionary<Guid, Entity>();

        public EntityManager(ServerEngine engine)
            : base(engine)
        {
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        protected override void OnRuntimeReset()
        {
            throw new NotImplementedException();
        }

        public override void Update(TimeSpan elapsedTime)
        {
            throw new NotImplementedException();
        }

        public Entity GetEntity(Guid id)
        {
            if (id == default(Guid))
            {
                return null;
            }

            return entities.ContainsKey(id) ? entities[id] : null;
        }

        public IEnumerable<Entity> GetEntities()
        {
            return entities.Values.ToList();
        }

        public Guid RegisterEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            if (entities.ContainsKey(entity.ID))
            {
                return entity.ID;
            }

            entity.ID = Guid.NewGuid();
            entity.Manager = this;

            entities.Add(entity.ID, entity);

            return entity.ID;
        }

        public void UnregisterEntity(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            if (!entities.Remove(entity.ID))
            {
                return;
            }

            entity.ID = default(Guid);
            entity.Manager = null;
        }
    }
}