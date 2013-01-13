using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.EntityFramework.Test.Infrastrucure {
    
    public class Book : IEntity<string> {

        public string Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishedOn { get; set; }

        public Person Person { get; set; }
    }
}