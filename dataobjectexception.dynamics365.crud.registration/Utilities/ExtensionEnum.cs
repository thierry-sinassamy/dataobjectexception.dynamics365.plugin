using System;

namespace dataobjectexception.dynamics365.crud.registration.Utilities
{
    public static class ExtensionEnum
    {
        public static T ToEnum<T>(this int parameter, out T result) where T: Enum
        {
            var enumType = typeof(T);
            var success = Enum.IsDefined(enumType, parameter);
            if (success)
            {
                result = (T)Enum.ToObject(enumType, parameter);
            }
            else
            {
                result = default(T);
            }
            return result;
        }
    }
}
