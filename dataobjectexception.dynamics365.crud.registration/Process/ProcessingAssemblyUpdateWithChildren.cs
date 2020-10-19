using dataobjectexception.dynamics365.crud.registration.Factories;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Message;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataobjectexception.dynamics365.crud.registration.Process
{
    public class ProcessingAssemblyUpdateWithChildren : Factory
    {
        //Properties
        private OrganizationServiceProxy OSP { get; }
        private EnumeratorProcessPluginAssembly EPPA { get; }

        //Copnstructor 
        public ProcessingAssemblyUpdateWithChildren(OrganizationServiceProxy organizationServiceProxy, EnumeratorProcessPluginAssembly enumeratorProcessPluginAssembly)
        {
            OSP = organizationServiceProxy;
            EPPA = enumeratorProcessPluginAssembly;
        }

        //Override
        [MethodMessage("Exception in the method [ProcessRegistration] : related to : " + ConstantesProcess.ProcessingAssemblyUpdateWithChildren)]
        public override void ProcessRegistration()
        {
            //todo
        }
    }
}
