using System;

namespace dataobjectexception.dynamics365.crud.registration.Message
{
    public class MethodMessage : Attribute
    {
        public string Message { get; set; }

        public MethodMessage(string message)
        {
            Message = message;
        }
    }
}
