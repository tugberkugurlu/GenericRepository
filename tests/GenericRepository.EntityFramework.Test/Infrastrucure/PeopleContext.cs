using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.EntityFramework.Test.Infrastrucure {

    public class PeopleContext : DbContext, IPeopleContext {

        public PeopleContext() { }

        public IDbSet<Person> People { get; set; }
        public IDbSet<Book> Books { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class {

            return base.Set<TEntity>();
        }
    }
}