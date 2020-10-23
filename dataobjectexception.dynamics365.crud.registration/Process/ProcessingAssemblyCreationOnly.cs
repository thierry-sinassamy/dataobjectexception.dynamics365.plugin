using dataobjectexception.dynamics365.crud.registration.Factories;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Message;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace dataobjectexception.dynamics365.crud.registration.Process
{
    public class ProcessingAssemblyCreationOnly : Factory
    {
        //Properties
        private IServiceContainer ServiceContainer { get; }
        private Dictionary<string, Root<PluginAssembly>> EPPA { get; }

        //Copnstructor 
        public ProcessingAssemblyCreationOnly(IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly) 
        {
            ServiceContainer = serviceContainer;
            EPPA = processingAssembly;
        }

        //Override
        [MethodMessage("Exception in the method [ProcessRegistration] : related to : " + ConstantesProcess.ProcessingAssemblyCreateOnly)]
        public override void ProcessRegistration()
        {
            //todo
        }
    }
}
