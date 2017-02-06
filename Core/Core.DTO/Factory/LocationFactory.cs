using Core.Domain;
namespace Core.DTO.Factory
{
    public class LocationFactory
    {
        CityFactory cityFactory = new CityFactory();
        StateFactory stateFactory = new StateFactory();
        CountryFactory countryFactory = new CountryFactory();
        public Location Create(LocationDTO locationDto)
        {
            return new Location()
            {
                LocationID = locationDto.LocationID,
                AddressLine1 = locationDto.AddressLine1,
                AddressLine2 = locationDto.AddressLine2,
                CountryID = locationDto.CountryID,
                StateID = locationDto.StateID,
                CityID = locationDto.CityID,
                Zip = locationDto.Zip,
                UDCID = locationDto.UDCID,
                //City = cityFactory.Create(locationDto.City),
                //State = stateFactory.Create(locationDto.State),
                //Country = countryFactory.Create(locationDto.Country)
            };
        }

        public LocationDTO Create(Location location)
        {
            return new LocationDTO()
            {
                LocationID = location.LocationID,
                AddressLine1 = location.AddressLine1,
                AddressLine2 = location.AddressLine2,
                CountryID = location.CountryID,
                StateID = location.StateID,
                CityID = location.CityID,
                Zip = location.Zip,
                UDCID = location.UDCID,
                City = location.City == null ? null : cityFactory.Create(location.City),
                State = location.State == null ? null : stateFactory.Create(location.State),
                Country = location.Country == null ? null : countryFactory.Create(location.Country)

            };
        }
    }
}
