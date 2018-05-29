using System;
using System.Collections.Generic;
using System.Text;

namespace NetCorePatterns.Singleton
{
    public class SingletonDisposableClass : IDisposable
    {
        private bool _disposed;
        //the volatile keyword ensures that the instantiation is complete 
        //before it can be accessed further helping with thread safety.
        private static volatile SingletonDisposableClass _instance;
        private static readonly object _syncLock = new object();

        // No one but itself can instanciate
        private SingletonDisposableClass()
        {
        }

        //uses a pattern known as double check locking
        public static SingletonDisposableClass Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonDisposableClass();
                    }
                }
                return _instance;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            // This object will be cleaned up by Dispose method.
            // Therefore, you should call GG.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the methos das been called directly
        // or indirectly by a uses's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged rerousces can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (_disposed) return;
            // If disposing equals true, dispose all managed
            // and unmanaged resources
            if (disposing)
            {
                _instance = null;
                // Dispose managed resources.
            }

            // Call the appropriate methods to clean up
            // unmanaged 
            _disposed = true;
        }

        public int SomeValue { get; set; }
    }
}
