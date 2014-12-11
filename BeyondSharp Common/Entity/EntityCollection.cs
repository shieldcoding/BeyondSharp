// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityCollection.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The EntityCollection interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Entity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// An entity collection stores entities while offering some enhancements such as an ID lookup, this is only primarily used by the entity managers.
    /// </summary>
    /// <typeparam name="TEntityType">
    /// The type of entity stored in this collection.
    /// </typeparam>
    /// <typeparam name="TEntityComponentType">
    /// The type of entity component contained by the entity.
    /// </typeparam>
    public class EntityCollection<TEntityType, TEntityComponentType> : ICollection<TEntityType>
        where TEntityType : IEntity<TEntityType, TEntityComponentType>
        where TEntityComponentType : IEntityComponent<TEntityType, TEntityComponentType>
    {
        /// <summary>
        /// The internal list of entities held by this collection.
        /// </summary>
        private readonly List<TEntityType> entityList = new List<TEntityType>();

        /// <summary>
        /// The internal dictionary lookup for entities based on their ID.
        /// </summary>
        private readonly Dictionary<Guid, TEntityType> entityLookup = new Dictionary<Guid, TEntityType>();

        /// <summary>
        /// Gets the number of entities contained within this collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.entityList.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only or not, which it will never be.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Adds an entity to the collection.
        /// </summary>
        /// <param name="item">
        /// The entity to be added to the collection.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Tried to add an entity to the collection, but received a null reference.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Tried to add an entity to the collection, but the entity does not have an ID.
        /// </exception>
        public void Add(TEntityType item)
        {
            if (item.Equals(null))
            {
                throw new ArgumentNullException();
            }

            if (item.ID == default(Guid))
            {
                throw new ArgumentException();
            }

            this.entityList.Add(item);
            this.entityLookup.Add(item.ID, item);
        }

        /// <summary>
        /// Empties the collection of all entities.
        /// </summary>
        public void Clear()
        {
            this.entityList.Clear();
            this.entityLookup.Clear();
        }

        /// <summary>
        /// Determines if an entity is contained within the collection.
        /// </summary>
        /// <param name="item">The entity to check.</param>
        /// <returns>True if the entity</returns>
        /// <exception cref="ArgumentNullException">
        /// Tried to determine if an entity was contained in the collection, but received a null reference.
        /// </exception>
        public bool Contains(TEntityType item)
        {
            if (item.Equals(null))
            {
                throw new ArgumentNullException();
            }

            return this.entityList.Contains(item);
        }

        /// <summary>
        /// Copies a list of entities from the collection to the array at the given offset.
        /// </summary>
        /// <param name="array">The array to copy entities to.</param>
        /// <param name="arrayIndex">The index </param>
        public void CopyTo(TEntityType[] array, int arrayIndex)
        {
            this.entityList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes an entity from the collection.
        /// </summary>
        /// <param name="item">The entity to be removed from the collection.</param>
        /// <returns>
        /// True if the entity was found and removed from the collection, false otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Tried to remove an entity from the collection, but received a null reference.
        /// </exception>
        public bool Remove(TEntityType item)
        {
            if (item.Equals(null))
            {
                throw new ArgumentNullException();
            }

            return this.entityList.Remove(item) | this.entityLookup.Remove(item.ID);
        }

        /// <summary>
        /// Retrieves an enumerator for enumerating over the collection.
        /// </summary>
        /// <returns>An enumerator for enumerating over the collection.</returns>
        public IEnumerator<TEntityType> GetEnumerator()
        {
            return this.entityList.GetEnumerator();
        }

        /// <summary>
        /// Retrieves an enumerator for enumerating over the collection.
        /// </summary>
        /// <returns>An enumerator for enumerating over the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.entityList.GetEnumerator();
        }

        /// <summary>
        /// Determines if an entity with the specified ID is contained within the collection.
        /// </summary>
        /// <param name="entityId">The ID of the entity to check.</param>
        /// <returns>True if an entity with the specified ID is contained within the collection, false otherwise.</returns>
        public bool Contains(Guid entityId)
        {
            return entityId != default(Guid) && this.entityLookup.ContainsKey(entityId);
        }

        /// <summary>
        /// Retrieves an entity with the specified ID if it is contained within the collection.
        /// </summary>
        /// <param name="entityId">The ID of the entity to retrieve.</param>
        /// <returns>The entity in the collection with the supplied ID, or the default (null) if there is no entity contained with that ID.</returns>
        public TEntityType GetEntity(Guid entityId)
        {
            if (entityId == default(Guid))
            {
                return default(TEntityType);
            }

            return this.entityLookup.ContainsKey(entityId) ? this.entityLookup[entityId] : default(TEntityType);
        }
    }
}