namespace BeyondSharp.Common.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface ISerializable<TOutput>
    {
        TOutput Serialize();

        void Deserialize(TOutput data);
    }
}
