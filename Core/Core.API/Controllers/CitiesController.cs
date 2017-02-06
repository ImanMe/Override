using Core.Domain.IRepositories;
using System;
using System.Linq;
using System.Web.Http;

namespace Core.API.Controllers
{
    [RoutePrefix("api")]
    public class CitiesController : BaseApiController
    {
        public CitiesController(IRepository repoParam) : base(repoParam)
        {
        }

        [Route("cities/{id}", Name = "CitiesList")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var cities = Repository.GetCitiesForState(id);

                if (cities == null)
                {
                    return NotFound();
                }

                return Ok(cities.ToList().OrderBy(c => c.Name).Select(c => CityFactory.Create(c)));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
