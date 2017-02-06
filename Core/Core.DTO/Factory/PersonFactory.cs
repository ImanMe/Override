using Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Core.DTO.Factory
{
    public class PersonFactory
    {
        LocationFactory locationFactory = new LocationFactory();
        public PersonDTO Create(Person person)
        {

            return new PersonDTO()
            {
                PersonID = person.PersonID,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                EmailAddress = person.EmailAddress,
                Locations = person.Locations.Select(e => locationFactory.Create(e)).ToList()

            };
        }

        public Person Create(PersonDTO person)
        {
            return new Person()
            {
                PersonID = person.PersonID,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                EmailAddress = person.EmailAddress,
                Locations = person.Locations == null ? new List<Location>() : person.Locations.Select(e => locationFactory.Create(e)).ToList()

            };
        }
    }
}
