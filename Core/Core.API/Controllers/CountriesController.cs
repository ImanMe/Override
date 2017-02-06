using Core.Domain;
using Core.Domain.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Core.DTO.Factory;
using System;

namespace Core.API.Controllers
{
    [RoutePrefix("api")]
    public class CountriesController : BaseApiController
    {
        public CountriesController(IRepository repoParam) : base(repoParam)
        {
        }

        [Route("countries", Name = "CountriesList")]
        public IHttpActionResult Get()
        {
            try
            {
                IQueryable<Country> countries = Repository.GetCountries();
                return Ok(countries
                    .ToList()
                    .OrderBy(c => c.Name)
                    .Select(c => CountryFactory.Create(c))
                    );
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            
        }
    }
}
