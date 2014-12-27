#region Usings

using System;

#endregion

namespace BeyondSharp.Common.Event
{
    public class ValueEventArgs<TValue1> : EventArgs
    {
        public ValueEventArgs(TValue1 value1)
        {
            Value1 = value1;
        }

        public TValue1 Value1 { get; private set; }
    }
}