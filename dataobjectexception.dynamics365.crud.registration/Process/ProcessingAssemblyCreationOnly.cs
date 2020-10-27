using dataobjectexception.dynamics365.crud.registration.Factories;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
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
        private Dictionary<string, Root<PluginAssembly>> ProcessingAssembly { get; }

        //Constructor 
        public ProcessingAssemblyCreationOnly(IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly) 
        {
            ServiceContainer = serviceContainer;
            ProcessingAssembly = processingAssembly;
        }

        //Override
        [MethodMessage("Exception in the method [ProcessRegistration] : related to : " + ConstantesProcess.ProcessingAssemblyCreateOnly)]
        public override void ProcessRegistration()
        {
            var repoPluginAssembly = (IRepository<Entities.PluginAssembly>)ServiceContainer.GetService(typeof(IRepository<Entities.PluginAssembly>));

            //Map the Pluginassembly Object with the fields of the CRM entity
            Entities.PluginAssembly pa = new Entities.PluginAssembly()
            {
                LogicalName = Entities.PluginAssembly.EntityLogicalName,
                //Id = Id,
                Attributes =
                {
                   //{"pluginassemblyid", Id },
                   //{"name", name } etc.
                }
            };
            repoPluginAssembly.CreateWithRequest(pa);
        }
    }
}
