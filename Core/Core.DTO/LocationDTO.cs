namespace Core.DTO
{
    public class LocationDTO
    {
        public int LocationID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string Zip { get; set; }
        public int UDCID { get; set; }
        public CityDTO City { get; set; }
        public StateDTO State { get; set; }
        public CountryDTO Country { get; set; }
    }
}
