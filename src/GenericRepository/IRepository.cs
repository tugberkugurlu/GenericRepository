using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GenericRepository {

    public interface IRepository<T> : IDisposable where T : class {

        void Upsert(T entity, Func<T, bool> insertExpression);
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        T Find(params object[] keyValues);
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        PaginatedList<T> Paginate(int pageIndex, int pageSize);
        PaginatedList<T> Paginate(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int pageIndex, int pageSize);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}