using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericRepository.EntityFramework {

    /// <summary>
    /// Entity Framework interface implementation for IRepository.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity which implements IEntity of int</typeparam>
    public interface IEntityRepository<TEntity> : IEntityRepository<TEntity, int>
        where TEntity : class, IEntity<int> {

    }
}