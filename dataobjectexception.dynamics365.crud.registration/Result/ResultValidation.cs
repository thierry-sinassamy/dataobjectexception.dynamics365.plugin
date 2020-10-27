using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.crud.registration.Result
{
    public class ResultValidation
    {
        public bool ObjectValidated { get; set; }
        public string Messagevalidation { get; set; }
        public Dictionary<int, string> KeyValueMessageValidation { get; set; }
        public string DisplayName { get; set; }
        public string Guid { get; set; }
        public EnumeratorProcessPluginAssembly EnumPluginAssembly {get; set;}
        public EnumeratorProcessPluginType EnumPluginType { get; set; }
        public EnumeratorProcessPluginStep EnumPluginStep { get; set; }
        public EnumeratorProcessPluginImage EnumPluginImage { get; set; }
        public bool ProcessValidated { get; set; }
        public EnumeratorProcessPluginAssembly Parameter { get; set; }
        public int LevelCount { get; set; }
        public EnumTagCreation TagCreate { get; set; }
        public EnumTagUpdate TagUpdate { get; set; }
        public EnumTagDelete TagDelete { get; set; }
    }
}
