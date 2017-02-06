using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class CityDTO
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        //public int StateID { get; set; }
        //public State State { get; set; }
        //public IEnumerable<PersonDTO> People { get; set; }
    }
}
