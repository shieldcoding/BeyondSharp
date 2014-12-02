using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity.Component.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SynchronizedComponentAttribute : Attribute
    {
        public string Identifier { get; set; }

        public SynchronizedComponentAttribute(string identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException();

            Identifier = identifier;
        }
    }
}
