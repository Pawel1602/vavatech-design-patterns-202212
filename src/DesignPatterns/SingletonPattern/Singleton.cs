using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Singleton<T>
        where T : class, new()
    {
        public static object syncLock = new();
        private static T _instance;
        public static T Instance
        {
            get
            {
                lock (syncLock)         // Monitor.Enter(syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }                       // Monitor.Exit(syncLock)

                return _instance;
            }
        }
    }

    public class LazySingleton<T>
        where T : class, new()
    {
        private static Lazy<T> _instance = new Lazy<T>(() => new T());
        public static T Instance => _instance.Value;
    }
}
