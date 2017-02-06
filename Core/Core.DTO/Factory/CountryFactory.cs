using Core.Domain;

namespace Core.DTO.Factory
{
    public class CountryFactory
    {
        public CountryDTO Create(Country country)
        {
            return new CountryDTO()
            {
                CountryID = country.CountryID,
                Name = country.Name,
                Code = country.Code,
            };
        }

        public Country Create(CountryDTO country)
        {
            return new Country()
            {
                CountryID = country.CountryID,
                Name = country.Name,
                Code = country.Code,
            };
        }
    }
}
