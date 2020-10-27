using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Process.UpdateChildren;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.crud.registration.Manager
{
    public class FactoryUpdateChildrenManager
    {
        private Dictionary<EnumTagUpdate, IFactoryUpdateChildren> _dictFactoryChildren = new Dictionary<EnumTagUpdate, IFactoryUpdateChildren>();

        public IFactoryUpdateChildren GetGroupingProcessing(EnumTagUpdate tag, IServiceContainer serviceContainer, Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            IFactoryUpdateChildren factoryUpdateChildren = null; // uses lazy initialization

            if (_dictFactoryChildren.ContainsKey(tag)) { factoryUpdateChildren = _dictFactoryChildren[tag]; }
            else
            {
                factoryUpdateChildren = tag switch
                {
                    EnumTagUpdate.Tag_PTU => new ProcessingUpdatePTU(serviceContainer, processingAssembly),
                    EnumTagUpdate.Tag_PTU_PTSC => new ProcessingUpdatePTU_PTSC(serviceContainer, processingAssembly),
                    EnumTagUpdate.Tag_PTU_PTSD => new ProcessingUpdatePTU_PTSD(serviceContainer, processingAssembly),
                    EnumTagUpdate.Tag_PTU_PTSU => new ProcessingUpdatePTU_PTSU(serviceContainer, processingAssembly),
                    EnumTagUpdate.Tag_PTU_PTSU_PTIC => new ProcessingUpdatePTU_PTSU_PTIC(serviceContainer, processingAssembly),
                    EnumTagUpdate.Tag_PTU_PTSU_PTID => new ProcessingUpdatePTU_PTSU_PTID(serviceContainer, processingAssembly),
                    EnumTagUpdate.Tag_PTU_PTSU_PTIU => new ProcessingUpdatePTU_PTSU_PTIU(serviceContainer, processingAssembly),
                    _ => throw new ArgumentOutOfRangeException(string.Empty, new StackTrace().GetFrame(0).GetMethod().Name),
                };
            }
            return factoryUpdateChildren;
        }
    }
}
