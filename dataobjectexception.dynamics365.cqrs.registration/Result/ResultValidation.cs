using dataobjectexception.dynamics365.cqrs.registration.Infrastructure;

namespace dataobjectexception.dynamics365.cqrs.registration.Result
{
    public class ResultValidation
    {
        public bool ObjectValidated { get; set; }
        public string Messagevalidation { get; set; }
        public string DisplayName { get; set; }
        public string Guid { get; set; }
        public EnumTag Tag { get; set; }
        public EnumeratorCommand Command { get; set; }
        public bool ProcessValidated { get; set; }       
    }
}
