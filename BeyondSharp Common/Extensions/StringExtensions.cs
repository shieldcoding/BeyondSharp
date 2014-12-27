#region Usings

using System;

#endregion

namespace BeyondSharp.Common.Extensions
{
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