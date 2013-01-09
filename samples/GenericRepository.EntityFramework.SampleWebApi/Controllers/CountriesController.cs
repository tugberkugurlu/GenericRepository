using AutoMapper;
using GenericRepository.EntityFramework.SampleCore.Entities;
using GenericRepository.EntityFramework.SampleWebApi.Dtos;
using GenericRepository.EntityFramework.SampleWebApi.RequestModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericRepository.EntityFramework.SampleWebApi.Controllers {

    public class CountriesController : ApiController {

        private readonly IEntityRepository<Country> _countryRepository;
        private readonly IMappingEngine _mapper;
        public CountriesController(IEntityRepository<Country> countryRepository, IMappingEngine mapper) {

            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        // GET api/countries?pageindex=1&pagesize=5
        public PaginatedDto<CountryDto> GetCountries(int pageIndex, int pageSize) {

            PaginatedList<Country> countries = _countryRepository.Paginate(pageIndex, pageSize);
            PaginatedDto<CountryDto> countryPaginatedDto = _mapper.Map<PaginatedList<Country>, PaginatedDto<CountryDto>>(countries);
            return countryPaginatedDto;
        }

        // GET api/countries/1
        public CountryDto GetCountry(int id) {

            Country country = _countryRepository.GetSingle(id);
            if (country == null) {

                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return _mapper.Map<Country, CountryDto>(country);
        }

        // POST api/countries
        public HttpResponseMessage PostCountry(CountryRequestModel requestModel) {

            Country country = _mapper.Map<CountryRequestModel, Country>(requestModel);
            country.CreatedOn = DateTimeOffset.Now;

            _countryRepository.Add(country);
            _countryRepository.Save();

            CountryDto countryDto = _mapper.Map<Country, CountryDto>(country);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, countryDto);
            response.Headers.Location = GetCountryLink(country.Id);

            return response;
        }

        // PUT api/countries/1
        public CountryDto PutCountry(int id, CountryRequestModel requestModel) {

            Country country = _countryRepository.GetSingle(id);
            if (country == null) {

                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // NOTE: AutoMapper goes bananas over this as 
            // EF creates the poroxy class for Country
            // Country updatedCountry = Mapper.Map<CountryRequestModel, Country>(requestModel, country);

            Country updatedCountry = requestModel.ToCountry(country);
            _countryRepository.Edit(updatedCountry);
            _countryRepository.Save();

            CountryDto countryDto = _mapper.Map<Country, CountryDto>(country);
            return countryDto;
        }

        // DELETE api/countries/1
        public HttpResponseMessage DeleteCountry(int id) {

            Country country = _countryRepository.GetSingle(id);
            if (country == null) {

                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _countryRepository.Delete(country);
            _countryRepository.Save();

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        private Uri GetCountryLink(int id) {

            return new Uri(Url.Link("DefaultHttpRoute", new { id = id }));
        }
    }
}