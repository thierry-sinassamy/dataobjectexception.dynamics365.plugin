using System;

namespace dataobjectexception.dynamics365.plugin.Registration
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class D365RegistrationPluginAttribute : Attribute
    {
        #region Enum List

        public enum MessageNameEnum
        {
            AddItem,
            AddListMembers,
            AddMember,
            AddMembers,
            AddPrincipalToQueue,
            AddPrivileges,
            AddProductToKit,
            AddRecurrence,
            AddToQueue,
            AddUserToRecordTeam,
            ApplyRecordCreationAndUpdateRule,
            Assign,
            Associate,
            BackgroundSend,
            Book,
            CalculatePrice,
            Cancel,
            CheckIncoming,
            CheckPromote,
            Clone,
            CloneMobileOfflineProfile,
            CloneProduct,
            Close,
            CopyDynamicListToStatic,
            CopySystemForm,
            Create,
            CreateException,
            CreateInstance,
            CreateKnowledgeArticleTranslation,
            CreateKnowledgeArticleVersion,
            Delete,
            DeleteOpenInstances,
            DeliverIncoming,
            DeliverPromote,
            Disassociate,
            Execute,
            ExecuteById,
            Export,
            GenerateSocialProfile,
            GetDefaultPriceLevel,
            GrantAccess,
            Import,
            LockInvoicePricing,
            LockSalesOrderPricing,
            Lose,
            Merge,
            ModifyAccess,
            PickFromQueue,
            Publish,
            PublishAll,
            PublishTheme,
            QualifyLead,
            Recalculate,
            ReleaseToQueue,
            RemoveFromQueue,
            RemoveItem,
            RemoveMember,
            RemoveMembers,
            RemovePrivilege,
            RemoveProductFromKit,
            RemoveRelated,
            RemoveUserFromRecordTeam,
            ReplacePrivileges,
            Reschedule,
            Retrieve,
            RetrieveExchangeRate,
            RetrieveFilteredForms,
            RetrieveMultiple,
            RetrievePersonalWall,
            RetrievePrincipalAccess,
            RetrieveRecordWall,
            RetrieveSharedPrincipalsAndAccess,
            RetrieveUnpublished,
            RetrieveUnpublishedMultiple,
            RetrieveUserQueues,
            RevokeAccess,
            RouteTo,
            Send,
            SendFromTemplate,
            SetLocLabels,
            SetRelated,
            SetState,
            TriggerServiceEndpointCheck,
            UnlockInvoicePricing,
            UnlockSalesOrderPricing,
            Update,
            ValidateRecurrenceRule,
            Win
        }
        public enum ExecutionModeEnum
        {
            Asynchronous,
            Synchronous
        }

        public enum IsolationModeEnum
        {
            None = 0,
            Sandbox = 1
        }

        public enum StageEnum
        {
            PreValidation = 10,
            PreOperation = 20,
            PostOperation = 40
        }

        public enum ImageTypeEnum
        {
            PreImage = 0,
            PostImage = 1,
            Both = 2
        }

        public enum PluginStepOperationEnum
        {
            Delete = 0,
            Deactivate = 1,
        }

        #endregion

        #region Constructor Mandatory Properties

        public IsolationModeEnum IsolationMode { get; private set; }
        public string Message { get; private set; }
        public string EntityLogicalName { get; private set; }
        public string FilteringAttributes { get; private set; }
        public string Name { get; private set; }
        public int ExecutionOrder { get; private set; }
        public StageEnum? Stage { get; private set; }
        public ExecutionModeEnum ExecutionMode { get; private set; }

        #endregion

        #region Named Properties
        public string Id { get; set; }
        public string FriendlyName { get; set; }
        public string GroupName { get; set; }
        public string Image1Name { get; set; }
        public string Image1Attributes { get; set; }
        public string Image2Name { get; set; }
        public string Image2Attributes { get; set; }
        public string Description { get; set; }
        public bool? DeleteAsyncOperaton { get; set; }
        public string UnSecureConfiguration { get; set; }
        public string SecureConfiguration { get; set; }
        public bool Offline { get; set; }
        public bool Server { get; set; }
        public ImageTypeEnum Image1Type { get; set; }
        public ImageTypeEnum Image2Type { get; set; }
        public PluginStepOperationEnum? Action { get; set; }
        #endregion

        public D365RegistrationPluginAttribute(string message,string entityLogicalName,StageEnum stage,ExecutionModeEnum executionMode,string filteringAttributes,string stepName,
                                                int executionOrder,IsolationModeEnum isolationModel)
        {
            Message = message;
            EntityLogicalName = entityLogicalName;
            FilteringAttributes = filteringAttributes;
            Name = stepName;
            ExecutionOrder = executionOrder;
            Stage = stage;
            ExecutionMode = executionMode;
            IsolationMode = isolationModel;
            Offline = false;
            Server = true;
        }

        public D365RegistrationPluginAttribute(MessageNameEnum message,string entityLogicalName, StageEnum stage,ExecutionModeEnum executionMode,
        string filteringAttributes,string stepName,int executionOrder,IsolationModeEnum isolationModel) : this(message.ToString(), entityLogicalName, stage, executionMode, filteringAttributes, stepName, executionOrder, isolationModel)
        {}
    }
}
