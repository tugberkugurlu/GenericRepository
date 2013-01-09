using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericRepository.EntityFramework.SampleCore.Entities {

    // NOTE: IEntity provides the integer Id parameter.
    // If your id type is other than integer, use IEntity<TId>
    public class Country : IEntity {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public virtual ICollection<Resort> Resorts { get; set; }
    }
}