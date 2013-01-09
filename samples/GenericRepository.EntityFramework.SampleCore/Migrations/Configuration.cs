using GenericRepository.EntityFramework.SampleCore.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GenericRepository.EntityFramework.SampleCore.Migrations {

    internal sealed class Configuration : DbMigrationsConfiguration<GenericRepository.EntityFramework.SampleCore.AccommodationEntities> {

        public Configuration() {

            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GenericRepository.EntityFramework.SampleCore.AccommodationEntities context) {

            context.Countries.AddOrUpdate(
                new Country { Id = 1, Name = "Turkey", ISOCode = "TR", CreatedOn = DateTimeOffset.Now },
                new Country { Id = 2, Name = "United Kingdom", ISOCode = "EN", CreatedOn = DateTimeOffset.Now },
                new Country { Id = 3, Name = "United States", ISOCode = "US", CreatedOn = DateTimeOffset.Now },
                new Country { Id = 4, Name = "Argentina", ISOCode = "AR", CreatedOn = DateTimeOffset.Now },
                new Country { Id = 4, Name = "Bahamas", ISOCode = "BS", CreatedOn = DateTimeOffset.Now },
                new Country { Id = 4, Name = "Uruguay", ISOCode = "UY", CreatedOn = DateTimeOffset.Now }
            );
        }
    }
}