using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepository.EntityFramework.Test.Infrastrucure {
    
    public class FakeDbSet<TEntity> : IDbSet<TEntity> where TEntity : class {

        ObservableCollection<TEntity> _collection;
        IQueryable _query;

        public FakeDbSet() {

            _collection = new ObservableCollection<TEntity>();
            _query = _collection.AsQueryable();
        }

        public TEntity Add(TEntity entity) {

            _collection.Add(entity);
            return entity;
        }


        public TEntity Attach(TEntity entity) {

            _collection.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity {

            return Activator.CreateInstance<TDerivedEntity>();
        }

        public TEntity Create() {

            return Activator.CreateInstance<TEntity>();
        }

        public TEntity Find(params object[] keyValues) {

            throw new NotImplementedException();
        }

        public ObservableCollection<TEntity> Local {

            get { return _collection; }
        }

        public TEntity Remove(TEntity entity) {

            _collection.Remove(entity);
            return entity;
        }

        public IEnumerator<TEntity> GetEnumerator() {

            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {

            return _collection.GetEnumerator();
        }

        public Type ElementType {
            get { return _query.ElementType; }
        }

        public Expression Expression {
            get { return _query.Expression; }
        }

        public IQueryProvider Provider {
            get { return _query.Provider; }
        }
    }
}