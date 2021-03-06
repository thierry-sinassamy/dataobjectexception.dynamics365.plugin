﻿using dataobjectexception.dynamics365.crud.registration.Factories;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Message;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace dataobjectexception.dynamics365.crud.registration.Process.CreateChildren
{
    public class ProcessingCreationPTC_PTSC : FactoryCreateChildren
    {
        //Properties
        private IServiceContainer ServiceContainer { get; }
        private Dictionary<string, Root<PluginAssembly>> ProcessingAssembly { get; }

        public ProcessingCreationPTC_PTSC(IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            ServiceContainer = serviceContainer;
            ProcessingAssembly = processingAssembly;
        }

        [MethodMessage("Exception in the method [ProcessRegistration] : related to : " + ConstantesProcess.ProcessingAssemblyCreateOnly)]
        public override void ProcessRegistrationCreateChildren()
        {
            //....
        }
    }
}
