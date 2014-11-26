﻿using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Entity
{
    public class ServerDatum : ICommonDatum
    {
        public string Tag { get; private set; }

        /// <summary>
        /// Unregisters the datum from the entity manager.
        /// </summary>
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
