namespace BeyondSharp.Common.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ValueEventArgs<TValue1> : EventArgs
    {
        public TValue1 Value1 { get; private set; }

        public ValueEventArgs(TValue1 value1)
        {
            Value1 = value1;
        }
    }
}
