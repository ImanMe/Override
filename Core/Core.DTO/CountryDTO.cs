using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class CountryDTO
    {
        public int CountryID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        //public bool Status { get; set; }
        //public IEnumerable<PersonDTO> People { get; set; }        
        //public IEnumerable<StateDTO> States { get; set; }
    }
}
