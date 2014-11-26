﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Entity
{
    /// <summary>
    /// The base entity-type for objects, datums in their base state are not shared between the server and its clients.
    /// </summary>
    public interface ICommonDatum
    {
        /// <summary>
        /// A unique tag that can be set and then used to retrieve this datum.
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Initiates the process of deleting the entity.
        /// </summary>
        void Delete();
    }
}
