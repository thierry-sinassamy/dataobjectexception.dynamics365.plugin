using dataobjectexception.dynamics365.crud.registration.DataContext;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Repository;
using System.ComponentModel.Design;

namespace dataobjectexception.dynamics365.crud.registration.Singleton
{
    public sealed class ThreadSafeSingleton
    {
        private static ServiceContainer _instance;
        private static readonly object _lock = new object();//to synchronize threads during first access to the Singleton.

        //https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
        /// <summary>
        /// Return one instance - Singleton
        /// </summary>
        public static ServiceContainer GetInstance(string connectionString)
        {
            if (_instance != null)
                lock (_lock)
                {
                    return _instance;
                }

            lock (_lock)
            {
                // The first thread to acquire the lock, reaches this conditional, goes inside and creates the Singleton
                // instance. Once it leaves the lock block, a thread that might have been waiting for the lock release may then
                // enter this section. But since the Singleton field is already initialized, the thread won't create a new object.
                if (_instance == null)
                    Initialize(connectionString);
            }            
            return _instance;
        }

        /// <summary>
        /// Initialize and set the configuration of the container for the injection.
        /// </summary>
        /// <returns>the container that has been created</returns>
        private static void Initialize(string connectionString)
        {
            _instance = new ServiceContainer();
            var datacontext = new Dynamics365EntitiesDataContext(connectionString);
            if (_instance.GetService(typeof(IDataContext)) == null)
                _instance.AddService(typeof(IDataContext), datacontext);

            //add repository
            if ((IRepository<Entities.PluginAssembly>)_instance.GetService(typeof(IRepository<Entities.PluginAssembly>)) == null)
                _instance.AddService(typeof(IRepository<Entities.PluginAssembly>), new PluginAssemblyRepository(datacontext));

            if ((IRepository<Entities.PluginType>)_instance.GetService(typeof(IRepository<Entities.PluginType>)) == null)
                _instance.AddService(typeof(IRepository<Entities.PluginType>), new PluginTypeRepository(datacontext));

            if ((IRepository<Entities.SdkMessageProcessingStep>)_instance.GetService(typeof(IRepository<Entities.SdkMessageProcessingStep>)) == null)
                _instance.AddService(typeof(IRepository<Entities.SdkMessageProcessingStep>), new PluginStepRepository(datacontext));

            if ((IRepository<Entities.SdkMessageProcessingStepImage>)_instance.GetService(typeof(IRepository<Entities.SdkMessageProcessingStepImage>)) == null)
                _instance.AddService(typeof(IRepository<Entities.SdkMessageProcessingStepImage>), new PluginStepImageRepository(datacontext));
        }

        /// <summary>
        /// Free the references in memory.
        /// </summary>
        public void Dispose()
        {
            _instance.Dispose();
        }
    }
}
