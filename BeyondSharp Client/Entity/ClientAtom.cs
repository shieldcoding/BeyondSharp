﻿using BeyondSharp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Entity
{
    internal abstract class ClientAtom : ClientDatum, ICommonAtom
    {
        public string Name { get; private set; }
    }
}