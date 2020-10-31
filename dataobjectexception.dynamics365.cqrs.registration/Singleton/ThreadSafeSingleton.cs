using dataobjectexception.dynamics365.cqrs.registration.DataContext;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.Singleton
{
    public sealed class ThreadSafeSingleton
    {
        private static IServiceProvider _instance;
        private static readonly object _lock = new object();//to synchronize threads during first access to the Singleton.

        //https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
        /// <summary>
        /// Return one instance - Singleton
        /// </summary>
        public static IServiceProvider GetInstance(string connectionString)
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

        private static void Initialize(string connectionString) 
        {
            var collection = new ServiceCollection();

            var datacontext = new Dynamics365EntitiesDataContext(connectionString);
            if (_instance.GetService(typeof(IDataContext)) == null)
                collection.AddSingleton<IDataContext>(datacontext);

            if ((IRepository<Entities.PluginAssembly>)_instance.GetService(typeof(IRepository<Entities.PluginAssembly>)) == null)
                collection.AddSingleton<IRepository<Entities.PluginAssembly>>(new PluginAssemblyRepository(datacontext));

            if ((IRepository<Entities.PluginType>)_instance.GetService(typeof(IRepository<Entities.PluginType>)) == null)
                 collection.AddSingleton<IRepository<Entities.PluginType>>(new PluginTypeRepository(datacontext));

             if ((IRepository<Entities.SdkMessageProcessingStep>)_instance.GetService(typeof(IRepository<Entities.SdkMessageProcessingStep>)) == null)
                 collection.AddSingleton<IRepository<Entities.SdkMessageProcessingStep>>(new PluginStepRepository(datacontext));

             if ((IRepository<Entities.SdkMessageProcessingStepImage>)_instance.GetService(typeof(IRepository<Entities.SdkMessageProcessingStepImage>)) == null)
                 collection.AddSingleton<IRepository<Entities.SdkMessageProcessingStepImage>>(new PluginStepImageRepository(datacontext));

            _instance = collection.BuildServiceProvider();
        }
    }
}
