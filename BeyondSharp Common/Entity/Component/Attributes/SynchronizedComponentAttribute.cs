namespace BeyondSharp.Common.Entity.Component.Attributes
{
    using System;

    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SynchronizedComponentAttribute : Attribute
    {
        public SynchronizedComponentAttribute(string identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException();
            }

            Identifier = identifier;
        }

        public string Identifier { get; set; }
    }
}