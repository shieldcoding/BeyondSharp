namespace BeyondSharp.Common.Entity
{
    using System;

    public interface IEntity<EntityComponentType>
        where EntityComponentType : IEntityComponent
    {
        Guid ID { get; }

        string Name { get; }

        string Description { get; }
    }
}