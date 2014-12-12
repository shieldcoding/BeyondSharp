using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Converts the object into a single-element enumeration.
        /// </summary>
        /// <typeparam name="ObjectType">The generic type to be used by the IEnumerable.</typeparam>
        /// <param name="object">The object to be encapsulated in the IEnumerable.</param>
        /// <returns>A single-element IEnumerable containing the object.</returns>
        public static IEnumerable<ObjectType> Yield<ObjectType>(this ObjectType @object)
        { yield return @object; }
    }
}
