using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;


namespace dataobjectexception.dynamics365.plugin.Contract
{
    public interface IDynamics365Repository<T> where T : Entity
    {
        IOrganizationService ServicesOrganization { get; }
        IServiceProvider ServiceProvider { get; }

        HttpClient OrganizationHttpClient { get; set; }

        T Find(Guid id);

        IEnumerable<T> FindAllWithFilter(params object[] args);
        T FindWithFilter(params object[] args);

        IEnumerable<T> FindFor(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindFor(QueryBase query);

        IEnumerable<T> FindAll();

        void Save(T entity);

        void Execute(OrganizationRequestCollection collection);

        void LoadProperty(T entity, string relationshipSchemaName);

        Guid Create(T entity);

        void Associate(T source, Relationship relationShip, IEnumerable<Entity> records);

        void Delete(T entity);

        void Disable(SetStateRequest setStateRequest);

        string GetOptionSetValueLabel(string fieldName, int optionSetValue);
    }
}
