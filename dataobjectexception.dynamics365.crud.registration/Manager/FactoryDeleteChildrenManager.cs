using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Process.DeleteChildren;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.crud.registration.Manager
{
    public class FactoryDeleteChildrenManager
    {
        private Dictionary<EnumTagDelete, IFactoryDeleteChildren> _dictFactoryChildren = new Dictionary<EnumTagDelete, IFactoryDeleteChildren>();

        public IFactoryDeleteChildren GetGroupingProcessing(EnumTagDelete tag, IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            IFactoryDeleteChildren factoryDeleteChildren = null; // uses lazy initialization

            if (_dictFactoryChildren.ContainsKey(tag)) { factoryDeleteChildren = _dictFactoryChildren[tag]; }
            else
            {
                factoryDeleteChildren = tag switch
                {
                    EnumTagDelete.Tag_PTD => new ProcessingDeletePTD(serviceContainer, processingAssembly),
                    EnumTagDelete.Tag_PTD_PTSD => new ProcessingDeletePTD_PTSD(serviceContainer, processingAssembly),
                    EnumTagDelete.Tag_PTD_PTSD_PTID => new ProcessingDeletePTD_PTSD_PTID(serviceContainer, processingAssembly),
                    _ => throw new ArgumentOutOfRangeException(string.Empty, new StackTrace().GetFrame(0).GetMethod().Name),
                };
            }
            return factoryDeleteChildren;
        }
    }
}
