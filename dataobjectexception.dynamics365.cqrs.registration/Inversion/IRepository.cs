﻿using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace dataobjectexception.dynamics365.cqrs.registration.Inversion
{
    public interface IRepository<T> where T : Entity
    {
        IDataContext Datacontext { get; }

        T Find(Guid id);
        IEnumerable<T> FindAllWithFilter(params object[] args);
        T FindWithFilter(params object[] args);
        T FindEntityByAttributes();
        IEnumerable<T> FindFor(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindFor(QueryBase query);
        IEnumerable<T> FindAll();
        List<T> FindAllEntititesByAttributes();
        OrganizationResponse UpdateWithRequest(T entity);
        Guid Create(T entity);
        OrganizationResponse CreateWithRequest(T entity);
        OrganizationResponse DeleteWithRequest(T entity);
        void Execute(OrganizationRequestCollection collection);
        void LoadProperty(T entity, string relationshipSchemaName);
        void Associate(T source, Relationship relationShip, IEnumerable<Entity> records);
        void Disable(SetStateRequest setStateRequest);
        string GetOptionSetValueLabel(string fieldName, int optionSetValue);
    }
}
