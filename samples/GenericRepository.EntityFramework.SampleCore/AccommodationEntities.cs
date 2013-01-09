using GenericRepository.EntityFramework.SampleCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GenericRepository.EntityFramework.SampleCore {
    
    public class AccommodationEntities : EntitiesContext {

        // NOTE: You have the same constructors as the DbContext here. E.g:
        // public AccommodationEntities() : base("nameOrConnectionString") { }

        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Resort> Resorts { get; set; }
        public IDbSet<Hotel> Hotels { get; set; }
    }
}