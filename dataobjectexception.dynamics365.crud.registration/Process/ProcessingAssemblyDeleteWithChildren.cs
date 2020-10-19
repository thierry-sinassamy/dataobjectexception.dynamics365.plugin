using dataobjectexception.dynamics365.crud.registration.Factories;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Message;
using Microsoft.Xrm.Sdk.Client;

namespace dataobjectexception.dynamics365.crud.registration.Process
{
    public class ProcessingAssemblyDeleteWithChildren : Factory
    {
        //Properties
        private OrganizationServiceProxy OSP { get; }
        private EnumeratorProcessPluginAssembly EPPA { get; }

        //Copnstructor 
        public ProcessingAssemblyDeleteWithChildren(OrganizationServiceProxy organizationServiceProxy, EnumeratorProcessPluginAssembly enumeratorProcessPluginAssembly)
        {
            OSP = organizationServiceProxy;
            EPPA = enumeratorProcessPluginAssembly;
        }

        //Override
        [MethodMessage("Exception in the method [ProcessRegistration] : related to : " + ConstantesProcess.ProcessingAssemblyDeleteWithChildren)]
        public override void ProcessRegistration()
        {
            //todo
        }
    }
}
