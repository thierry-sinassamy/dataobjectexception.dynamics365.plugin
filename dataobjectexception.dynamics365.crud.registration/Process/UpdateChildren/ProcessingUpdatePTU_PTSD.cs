using dataobjectexception.dynamics365.crud.registration.Factories;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Message;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace dataobjectexception.dynamics365.crud.registration.Process.UpdateChildren
{
    public class ProcessingUpdatePTU_PTSD : FactoryUpdateChildren
    {
        //Properties
        private IServiceContainer ServiceContainer { get; }
        private Dictionary<string, Root<PluginAssembly>> ProcessingAssembly { get; }

        public ProcessingUpdatePTU_PTSD(IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            ServiceContainer = serviceContainer;
            ProcessingAssembly = processingAssembly;
        }

        [MethodMessage("Exception in the method [ProcessRegistration] : related to : " + ConstantesProcess.ProcessingAssemblyUpdateWithChildren)]
        public override void ProcessRegistrationUpdateChildren()
        {
            //....
        }
    }
}
