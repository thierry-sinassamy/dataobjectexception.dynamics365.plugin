using dataobjectexception.dynamics365.crud.registration.Inversion;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace dataobjectexception.dynamics365.crud.registration.DataContext
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        public IDataContext Datacontext { get; private set; }

        protected Repository(IDataContext dataContext)
        {
            Datacontext = dataContext;
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

        public virtual T FindEntityByAttributes()
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

        public virtual List<T> FindAllEntititesByAttributes()
        {
            throw new NotImplementedException();
        }

        public virtual OrganizationResponse Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Guid Create(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual OrganizationResponse CreateWithRequest(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual OrganizationResponse Delete(T entity)
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
        public virtual void Associate(T source, Relationship relationShip, IEnumerable<Entity> records)
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
