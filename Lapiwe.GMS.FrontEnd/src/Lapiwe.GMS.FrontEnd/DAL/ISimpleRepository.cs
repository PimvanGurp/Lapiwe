using Lapiwe.Common.Domain;
using System;
using System.Collections.Generic;

namespace Lapiwe.GMS.FrontEnd.DAL
{
    public interface ISimpleRepository
    {
        IEnumerable<TEntity> FindAll<TEntity>() where TEntity : DomainEntity;
        TEntity Find<TEntity>(Guid guid) where TEntity : DomainEntity;
        void Add<TEntity>(TEntity entity) where TEntity : DomainEntity;
    }
}