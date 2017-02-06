using Core.Domain;

namespace Core.DTO
{
    public class CompanyLocationDTO
    {
        public int CompanyLocationID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string Zip { get; set; }
        public int UDCID { get; set; }
        public UDC UDC { get; set; }
    }
}
