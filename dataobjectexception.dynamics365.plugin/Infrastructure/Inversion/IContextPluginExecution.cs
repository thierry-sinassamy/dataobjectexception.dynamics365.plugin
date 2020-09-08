using System;
using System.ComponentModel.Design;
using Microsoft.Xrm.Sdk;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.Inversion
{
    public interface IContextPluginExecution<TEntity> where TEntity : Entity
    {
        string Message { get; set; }
        bool Synchronous { get; set; }
        int Stage { get; set; }
        string OrganizationName { get; set; }
        Entity EntityInput { get; set; }
        TEntity EntityCurrent { get; set; }
        TEntity EntityBefore { get; set; }
        TEntity EntityAfter { get; set; }
        Guid? UserId { get; set; }
        Guid? InitiatorId { get; set; }
        IServiceContainer ServiceContainer { get; set; }
    }
}
