using Core.Domain;
using Core.Domain.IRepositories;
using System;
using System.Linq;
using System.Web.Http;

namespace Core.API.Controllers
{
    [RoutePrefix("api")]
    public class LocationsController : BaseApiController
    {

        public LocationsController(IRepository repoParam) : base(repoParam)
        {
        }

        [HttpGet]
        [Route("locations")]
        public IHttpActionResult Get()
        {
            try
            {
                IQueryable<Location> location = Repository.GetLocations();
                return Ok(location.ToList().OrderBy(p => p.LocationID).Select(p => LocationFactory.Create(p)));
            }
            catch (System.Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("locations/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var location = Repository.GetLocation(id);

                if (location == null)
                {
                    return NotFound();
                }

                return Ok(LocationFactory.Create(location));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
