using System;

namespace Common.Helpers.Patterns
{
    public class Singleton<T>
    {
        private static T _instance;
        private static Object _lock = new Object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)Activator.CreateInstance(typeof(T));

                        if (_instance == null)
                        {
                            Console.WriteLine("ERROR CREATING SINGLETON");
                        }
                    }
                    return _instance;
                }
            }
        }
    }
}