using System;
using System.Collections.Generic;
using System.Text;

namespace NetCorePatterns.Singleton
{
    public class SingletonClass
    {
        private bool _disposed;
        //the volatile keyword ensures that the instantiation is complete 
        //before it can be accessed further helping with thread safety.
        private static volatile SingletonClass _instance;
        private static readonly object _syncLock = new object();

        // No one but itself can instanciate
        private SingletonClass()
        {
        }

        //uses a pattern known as double check locking
        public static SingletonClass Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonClass();
                    }
                }
                return _instance;
            }
        }

        public int SomeValue { get; set; }
    }
}
