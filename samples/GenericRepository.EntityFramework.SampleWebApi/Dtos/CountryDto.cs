using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRepository.EntityFramework.SampleWebApi.Dtos {
    
    public class CountryDto : IDto {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}