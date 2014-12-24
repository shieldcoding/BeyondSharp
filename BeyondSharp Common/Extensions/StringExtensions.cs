namespace BeyondSharp.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;


    public static class StringExtensions
    {
        public static string FormatKeyWithValue(this string self, string key, string value)
        {
            if (self == null)
                throw new ArgumentNullException();

            return self.Replace('{' + key + '}', value);
        }
    }
}
