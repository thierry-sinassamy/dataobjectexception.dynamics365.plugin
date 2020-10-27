using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Process.CreateChildren;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.crud.registration.Manager
{
    public class FactoryCreationChildrenManager
    {
        private Dictionary<EnumTagCreation, IFactoryCreateChildren> _dictFactoryChildren = new Dictionary<EnumTagCreation, IFactoryCreateChildren>();

        public IFactoryCreateChildren GetGroupingProcessing(EnumTagCreation tag, IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            IFactoryCreateChildren factoryCreateChildren = null; // uses lazy initialization

            if (_dictFactoryChildren.ContainsKey(tag)) { factoryCreateChildren = _dictFactoryChildren[tag]; }
            else
            {
                factoryCreateChildren = tag switch
                {
                    EnumTagCreation.Tag_PTC => new ProcessingCreationPTC(serviceContainer, processingAssembly),
                    EnumTagCreation.Tag_PTC_PTSC => new ProcessingCreationPTC_PTSC(serviceContainer, processingAssembly),
                    EnumTagCreation.Tag_PTC_PTSC_PTIC => new ProcessingCreationPTC_PTSC_PTIC(serviceContainer, processingAssembly),
                    _ => throw new ArgumentOutOfRangeException(string.Empty, new StackTrace().GetFrame(0).GetMethod().Name),
                };
            }
            return factoryCreateChildren;
        }
    }
}
