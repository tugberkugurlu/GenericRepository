using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.EntityFramework.Test.Infrastrucure {

    public class PeopleContext : EntitiesContext, IPeopleContext {

        public PeopleContext() { }

        public IDbSet<Person> People { get; set; }
        public IDbSet<Book> Books { get; set; }
    }
}