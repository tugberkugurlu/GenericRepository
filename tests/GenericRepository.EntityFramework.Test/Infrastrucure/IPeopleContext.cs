using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.EntityFramework.Test.Infrastrucure {
    
    public interface IPeopleContext : IDisposable, IEntitiesContext {

        IDbSet<Person> People { get; set; }
        IDbSet<Book> Books { get; set; }
    }
}