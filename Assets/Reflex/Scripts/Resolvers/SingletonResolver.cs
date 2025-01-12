﻿using System;

namespace Reflex
{
    internal class SingletonResolver : IResolver
    {
        private object _instance;
        public Type Concrete { get; }
        public int Resolutions { get; private set; }

        public SingletonResolver(Type concrete)
        {
            Concrete = concrete;
        }

        public object Resolve(Container container)
        {
            Resolutions++;
            
            if (_instance == null)
            {
                _instance = container.Construct(Concrete);
            }

            return _instance;
        }
    }
}