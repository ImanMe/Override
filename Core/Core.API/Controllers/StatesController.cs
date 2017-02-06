using Core.Domain.IRepositories;
using Core.DTO.Factory;
using System;
using System.Linq;
using System.Web.Http;

namespace Core.API.Controllers
{
    [RoutePrefix("api")]
    public class StatesController : BaseApiController
    {
        public StatesController(IRepository repoParam) : base(repoParam)
        {
        }

        [Route("states/{id}", Name = "StatesList")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var states = Repository.GetStatesForCountry(id);
                if (states == null)
                {
                    return NotFound();
                }

                return Ok(states.ToList().OrderBy(s => s.Name).Select(s => StateFactory.Create(s)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
