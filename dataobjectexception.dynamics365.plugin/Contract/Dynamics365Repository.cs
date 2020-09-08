using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace dataobjectexception.dynamics365.plugin.Contract
{
    public abstract class Dynamics365Repository<T> : IDynamics365Repository<T> where T : Entity
    {
        public IOrganizationService ServicesOrganization { get; }
        public IServiceProvider ServiceProvider { get; }
        public HttpClient OrganizationHttpClient { get; set; }

        protected Dynamics365Repository(IContextDynamics365Service contextDynamics365Service)
        {
            ServicesOrganization = contextDynamics365Service.OrganizationServiceUser;
            ServiceProvider = contextDynamics365Service.ServiceProvider;
        }

        public virtual T Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAllWithFilter(params object[] args)
        {
            throw new NotImplementedException();
        }

        public virtual T FindWithFilter(params object[] args)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindFor(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindFor(QueryBase query)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Save(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Execute(OrganizationRequestCollection collection)
        {
            throw new NotImplementedException();
        }

        public virtual void LoadProperty(T entity, string relationshipSchemaName)
        {
            throw new NotImplementedException();
        }

        public virtual Guid Create(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Associate(T source, Relationship relationShip, IEnumerable<Entity> records)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Disable(SetStateRequest setStateRequest)
        {
            throw new NotImplementedException();
        }

        public virtual string GetOptionSetValueLabel(string fieldName, int optionSetValue)
        {
            throw new NotImplementedException();
        }
    }
}
