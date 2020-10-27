using dataobjectexception.dynamics365.crud.registration.Factories;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Message;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace dataobjectexception.dynamics365.crud.registration.Process
{
    public class ProcessingAssemblyCreationWithChildren : Factory
    {
        //Properties
        private IServiceContainer ServiceContainer { get; }
        private Dictionary<string, Root<PluginAssembly>> ProcessingAssembly { get; }

        //Copnstructor 
        public ProcessingAssemblyCreationWithChildren(IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            ServiceContainer = serviceContainer;
            ProcessingAssembly = processingAssembly;
        }

        //Override
        [MethodMessage("Exception in the method [ProcessRegistration] : related to : " + ConstantesProcess.ProcessingAssemblyCreationWithChildren)]
        public override void ProcessRegistration()
        {
            //todo - validate the children to create
            //ValidateRulePTC...
            //Validate cas 1 : PT (pluginType) already existing
        }
    }
}
