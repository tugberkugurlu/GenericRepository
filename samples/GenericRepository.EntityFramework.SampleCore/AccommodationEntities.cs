using GenericRepository.EntityFramework.SampleCore.Entities;
using System.Data.Entity;

namespace GenericRepository.EntityFramework.SampleCore {
    
    public class AccommodationEntities : EntitiesContext {

        // NOTE: You have the same constructors as the DbContext here. E.g:
        // public AccommodationEntities() : base("nameOrConnectionString") { }

        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Resort> Resorts { get; set; }
        public IDbSet<Hotel> Hotels { get; set; }
    }
}