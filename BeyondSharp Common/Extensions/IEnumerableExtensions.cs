// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEnumerableExtensions.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The i enumerable extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// The i enumerable extensions.
    /// </summary>
    public static class IEnumerableExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts the object into a single-element enumeration.
        /// </summary>
        /// <typeparam name="ObjectType">
        /// The generic type to be used by the IEnumerable.
        /// </typeparam>
        /// <param name="object">
        /// The object to be encapsulated in the IEnumerable.
        /// </param>
        /// <returns>
        /// A single-element IEnumerable containing the object.
        /// </returns>
        public static IEnumerable<ObjectType> Yield<ObjectType>(this ObjectType @object)
        {
            yield return @object;
        }

        #endregion
    }
}