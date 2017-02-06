using System.Collections.Generic;

namespace Core.DTO
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<LocationDTO> Locations { get; set; }
    }
}
