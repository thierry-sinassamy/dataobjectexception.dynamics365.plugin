using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Process;
using dataobjectexception.dynamics365.crud.registration.Result;
using dataobjectexception.dynamics365.crud.registration.Utilities;
using Microsoft.Xrm.Sdk.Client;
using System;

namespace dataobjectexception.dynamics365.crud.registration.Manager
{
    public class FactoryManager
    {
        public IFactory GenerateFactories(ResultValidation resultValidation, OrganizationServiceProxy Service, int Parameter)
        {
            IFactory factory;
            switch (resultValidation.Parameter) 
            {
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyCreationOnly:
                    factory = new ProcessingAssemblyCreationOnly(Service, Parameter.ToEnum<EnumeratorProcessPluginAssembly>(out _));
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyCreationWithChildren:
                    factory = new ProcessingAssemblyCreationWithChildren(Service, Parameter.ToEnum<EnumeratorProcessPluginAssembly>(out _));
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateOnly:
                    factory = new ProcessingAssemblyUpdateOnly(Service, Parameter.ToEnum<EnumeratorProcessPluginAssembly>(out _)); ;
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateWithChildren:
                    factory = new ProcessingAssemblyUpdateWithChildren(Service, Parameter.ToEnum<EnumeratorProcessPluginAssembly>(out _)); ;
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyDeleteOnly:
                    factory = new ProcessingAssemblyDeleteOnly(Service, Parameter.ToEnum<EnumeratorProcessPluginAssembly>(out _)); ;
                    break;
                case EnumeratorProcessPluginAssembly.ProcessingAssemblyDeleteWithChildren:
                    factory = new ProcessingAssemblyDeleteWithChildren(Service, Parameter.ToEnum<EnumeratorProcessPluginAssembly>(out _)); ;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(resultValidation.Parameter), resultValidation.DisplayName);
            }
            return factory;
        }
    }
}
