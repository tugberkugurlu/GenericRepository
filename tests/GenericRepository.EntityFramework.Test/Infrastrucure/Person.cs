using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.EntityFramework.Test.Infrastrucure {
    
    public class Person : IEntity {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}