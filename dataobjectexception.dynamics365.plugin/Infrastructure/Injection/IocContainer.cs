using System.ComponentModel.Design;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.Injection
{
    public sealed class IocContainer
    {
        private static ServiceContainer _instance;
        private static readonly object Locker = new object();

        public IServiceContainer ServiceContainer { get; set; }

        /// <summary>
        /// Return one instance - Singleton
        /// </summary>
        public static ServiceContainer Instance
        {
            get
            {
                if (_instance != null)
                    lock (Locker)
                    {
                        return _instance;
                    }

                lock (Locker)
                {
                    if (_instance == null)
                        Initialize();
                }
                // ReSharper disable once InconsistentlySynchronizedField
                return _instance;
            }
        }


        /// <summary>
        /// Initialize and set the configuration of the container for the injection.
        /// </summary>
        /// <returns>the container that has been created</returns>
        private static void Initialize()
        {
            _instance = new ServiceContainer(); 
        }

        /// <summary>
        /// Free the references in memory.
        /// </summary>
        public void Dispose()
        {
            Instance.Dispose();
        }
    }
}
