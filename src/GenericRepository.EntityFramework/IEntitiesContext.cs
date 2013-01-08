using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace GenericRepository.EntityFramework {

    public interface IEntitiesContext : IDisposable {

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : class;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : class;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}