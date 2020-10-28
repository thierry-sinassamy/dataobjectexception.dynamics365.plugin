namespace dataobjectexception.dynamics365.crud.registration.Infrastructure
{
    public enum EnumeratorProcessPluginAssembly
    {
        ProcessingAssemblyUpdateOnly,
        ProcessingAssemblyCreationOnly,
        ProcessingAssemblyDeleteOnly,
        ProcessingAssemblyUpdateWithChildren,
        ProcessingAssemblyCreationWithChildren,
        ProcessingAssemblyDeleteWithChildren
    }

    public enum EnumTagCreation
    {
        Tag_Assembly_C,
        Tag_Assembly_C_With_Children,
        Tag_PTC,
        Tag_PTC_PTSC,
        Tag_PTC_PTSC_PTIC
    }

    public enum EnumTagUpdate
    {
        Tag_Assembly_U,
        Tag_Assembly_U_With_Children,
        Tag_PTU,
        Tag_PTU_PTSC,
        Tag_PTU_PTSD,
        Tag_PTU_PTSU,
        Tag_PTU_PTSU_PTIC,
        Tag_PTU_PTSU_PTID,
        Tag_PTU_PTSU_PTIU
    }

    public enum EnumTagDelete
    {
        Tag_Assembly_D,
        Tag_Assembly_D_With_Children,
        Tag_PTD,
        Tag_PTD_PTSD,
        Tag_PTD_PTSD_PTID
    }

    public enum EnumeratorProcessPluginType
    {
        ProcessingPluginUpdate,
        ProcessingPluginCreation,
        ProcessingPluginDelete
    }

    public enum EnumeratorProcessPluginStep
    {
        ProcessingPluginStepUpdate,
        ProcessingPluginStepCreation,
        ProcessingPluginStepDelete
    }

    public enum EnumeratorProcessPluginImage
    {
        ProcessingPluginImageUpdate,
        ProcessingPluginImageCreation,
        ProcessingPluginImageDelete
    }

    public enum PluginAssemblyIsolationMode
    {
        None = 1,
        Sandbox = 2,
        External = 3
    }

    public enum PluginAssemblySourceType
    {
        Database = 0,
        Disk = 1,
        Normal = 2
    }

    public enum PluginAssemblyComponentState
    {
        Published = 0,
        Unpublished = 1,
        Deleted = 2,
        DeletedUnpublished = 3
    }

    public enum PluginTypeComponentState
    {
        Published = 0,
        Unpublished = 1,
        Deleted = 2,
        DeletedUnpublished = 3
    }

    public enum ImageType
    {
        PreImage = 0,
        PostImage = 1,
        Both = 2
    }

    public enum PluginImageComponentState
    {
        Published = 0,
        Unpublished = 1,
        Deleted = 2,
        DeletedUnpublished = 3
    }

    public enum PluginStepMode
    {
        Synchronous = 0,
        Asynchronous = 1
    }

    public enum PluginStepStage
    {
        InitialPreOperation = 5, //for internal use only
        PreValidation = 10,
        InternalPreOperationBEP = 15, //for internal use only - before external plugins (BEP)
        PreOperation = 20,
        InternalPreOperationAEP = 25, //for internal use only - after external plugins (AEP)
        MainOperation = 30, //for internal use only
        InternalPostOperationBEP = 35, //for internal use only - before external plugins (BEP)
        PostOperation = 40,
        InternalPostOperationAEP = 45, //for internal use only - after external plugins (AEP)
        FinalPostOperation = 55, //for internal use only
        PreCommitStage = 80, //before transaction commit (For internal use only)
        PostCommitStage = 90 //after transaction commit (For internal use only)
    }

    public enum PluginStepSupportedDeployment
    {
        ServerOnly = 0,
        OutlookOnly = 1,
        Both = 2
    }

    public enum PluginStepComponentState
    {
        Published = 0,
        Unpublished = 1,
        Deleted = 2,
        DeletedUnpublished = 3
    }
}
