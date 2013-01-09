using GenericRepository.EntityFramework.SampleCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericRepository.EntityFramework.SampleCore {
    
    public static class HotelRepositoryExtensions {

        public static IQueryable<Hotel> GetAllByResortId(this IEntityRepository<Hotel, int> hotelRepository, int resortId) {

            return hotelRepository.FindBy(x => x.ResortId == resortId);
        }
    }
}