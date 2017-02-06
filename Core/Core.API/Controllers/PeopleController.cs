using Core.Domain;
using Core.Domain.IRepositories;
using Core.DTO;
using Marvin.JsonPatch;
using System;
using System.Linq;
using System.Web.Http;

namespace Core.API.Controllers
{
    [RoutePrefix("api")]
    public class PeopleController : BaseApiController
    {
        public PeopleController(IRepository repoParam) : base(repoParam)
        {
        }


        [Route("people", Name = "PeopleList")]
        public IHttpActionResult Get()
        {
            try
            {
                IQueryable<Person> person = Repository.GetPeopleWithLocations();
                return Ok(person.ToList().OrderBy(p => p.PersonID).Select(p => PersonFactory.Create(p)));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("people/{id}", Name = "Person")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var person = Repository.GetPersonWithLocations(id);

                if (person == null)
                {
                    return NotFound();
                }
                return Ok(PersonFactory.Create(person));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("people")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]PersonDTO personDto)
        {
            try
            {
                if (personDto == null)
                {
                    return BadRequest();
                }

                var person = PersonFactory.Create(personDto);

                var result = Repository.InsertPerson(person);

                if (result > 0)
                {
                    var newPerson = Repository.GetPersonWithLocations(person.PersonID);

                    return Created<PersonDTO>(Request.RequestUri
                       + "/" + newPerson.PersonID.ToString(), PersonFactory.Create(newPerson));
                }

                return BadRequest();
            }

            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("people/{id}")]
        public IHttpActionResult Put(int id, [FromBody]PersonDTO personDto)
        {
            try
            {
                var existingPerson = Repository.GetPerson(id);

                if (existingPerson == null)
                {
                    return NotFound();
                }

                if (personDto == null)
                {
                    return BadRequest();
                }

                var person = PersonFactory.Create(personDto);

                var result = Repository.UpdatePerson(person);
                if (result > 0)
                {
                    var modifiedPerson = Repository.GetPersonWithLocations(id);
                    return Created<PersonDTO>(Request.RequestUri
                       + "/" + modifiedPerson.PersonID.ToString(), PersonFactory.Create(modifiedPerson));
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //This is how patch should be called
        // Contetnt-Type     application/json-patch+json
        //[
        //{ "op": "add", 
        //  "path": "/firstName", 
        //  "value": "BenTest"
        //},
        //{ "op": "add", 
        //"path": "/locations/0/zip", 
        //"value": "222222" 
        //}
        //]
        [HttpPatch]
        [Route("people/{id}")]
        public IHttpActionResult Patch(int id,
            [FromBody]JsonPatchDocument<PersonDTO> personPatchDocument)
        {
            try
            {
                if (personPatchDocument == null)
                {
                    return BadRequest();
                }

                var person = Repository.GetPerson(id);

                if (person == null)
                {
                    return NotFound();
                }

                // map
                var personDto = PersonFactory.Create(person);

                // apply changes to the DTO
                personPatchDocument.ApplyTo(personDto);

                // map the DTO with applied changes to the entity, & update
                var modifiyingPerson = PersonFactory.Create(personDto);
                var result = Repository.UpdatePerson(modifiyingPerson);

                if (result > 0)
                {
                    // map to dto
                    var modifiedPerson = Repository.GetPerson(id);
                    return Ok(PersonFactory.Create(modifiedPerson));
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
