using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Process;
using dataobjectexception.dynamics365.crud.registration.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace dataobjectexception.dynamics365.crud.registration.Manager
{
    public class FactoryManager
    {
        public IFactory GenerateFactories(ResultValidation resultValidation, IServiceContainer Service, Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            IFactory factory;
            switch (resultValidation.Parameter) 
            {
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyCreationOnly:
                    factory = new ProcessingAssemblyCreationOnly(Service, processingAssembly);
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyCreationWithChildren:
                    factory = new ProcessingAssemblyCreationWithChildren(Service, processingAssembly);
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateOnly:
                    factory = new ProcessingAssemblyUpdateOnly(Service, processingAssembly); ;
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateWithChildren:
                    factory = new ProcessingAssemblyUpdateWithChildren(Service, processingAssembly); ;
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyDeleteOnly:
                    factory = new ProcessingAssemblyDeleteOnly(Service, processingAssembly); ;
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyDeleteWithChildren:
                    factory = new ProcessingAssemblyDeleteWithChildren(Service, processingAssembly); ;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(resultValidation.Parameter), resultValidation.DisplayName);
            }
            return factory;
        }
    }
}
