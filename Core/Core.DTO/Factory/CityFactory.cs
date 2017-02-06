using Core.Domain;

namespace Core.DTO.Factory
{
    public class CityFactory
    {
        public CityDTO Create(City city)
        {
            return new CityDTO()
            {
                CityID = city.CityID,
                Name = city.Name,
                //State = city.State,
                //StateID = city.StateID
            };
        }

        public City Create(CityDTO city)
        {
            return new City()
            {
                CityID = city.CityID,
                Name = city.Name,
                //State = city.State,
                //StateID = city.StateID
            };
        }
    }
}
