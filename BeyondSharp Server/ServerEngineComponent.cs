﻿using BeyondSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server
{
    public abstract class ServerEngineComponent : IEngineComponent
    {
        public ServerEngine Engine { get; private set; }

        public ServerEngineComponent(ServerEngine engine)
        {
            Engine = engine;
        }

        public abstract void Initialize();

        public abstract void Update(TimeSpan elapsedTime);
    }
}
