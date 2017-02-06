using System.Linq;

namespace Core.Domain.IRepositories
{
    public interface IRepository
    {
        IQueryable<Country> GetCountries();
        IQueryable<State> GetStatesForCountry(int id);
        IQueryable<City> GetCitiesForState(int id);
        IQueryable<Person> GetPeople();
        IQueryable<Person> GetPeopleWithLocations();
        Person GetPerson(int id);
        Person GetPersonWithLocations(int id);
        int InsertPerson(Person person);
        int UpdatePerson(Person person);
        IQueryable<Company> GetCompanies();
        IQueryable<Person> GetLocationsForPerson(int id);
        IQueryable<Location> GetLocations();
        Location GetLocation(int id);
    }
}
