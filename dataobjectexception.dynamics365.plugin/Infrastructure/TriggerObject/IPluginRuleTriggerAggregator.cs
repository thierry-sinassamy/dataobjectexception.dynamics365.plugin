using System.Collections.Generic;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk;

namespace dataobjectexception.dynamics365.plugin.Infrastructure.TriggerObject
{
    public interface IPluginRuleTriggerAggregator<T> where T : Entity
    {
        List<IPluginRuleTrigger<T>> CombineEntityRules(IContextPluginExecution<T> contextPluginExecution);
    }
}
