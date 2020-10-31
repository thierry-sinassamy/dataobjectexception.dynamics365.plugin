namespace dataobjectexception.dynamics365.cqrs.registration.Infrastructure
{
    public enum EnumeratorCommand
    {
        AdjustPluginAssemblyCommand,
        RegisterPluginAssemblyCommand,
        UnregisterPluginAssemblyCommand
    }

    public enum EnumTag
    {
        Tag_Adjust,
        Tag_Register,
        Tag_UnRegister        
    }
}
