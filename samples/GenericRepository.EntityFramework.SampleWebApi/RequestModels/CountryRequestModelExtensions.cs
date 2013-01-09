using GenericRepository.EntityFramework.SampleCore.Entities;
using GenericRepository.EntityFramework.SampleWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRepository.EntityFramework.SampleWebApi.RequestModels {
    
    public static class CountryRequestModelExtensions {

        public static Country ToCountry(this CountryRequestModel requestModel, Country source) {

            source.Name = requestModel.Name;
            source.ISOCode = requestModel.ISOCode;

            return source;
        }
    }
}