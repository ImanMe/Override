using Core.Domain.IRepositories;
using System.Data.Entity;
using System.Linq;

namespace Core.Domain.Repositories
{
    public class Repository : IRepository
    {
        private CoreContext context;
        public Repository(CoreContext contextParam)
        {
            context = contextParam;
        }

        public IQueryable<Country> GetCountries()
        {
            return context.Countries
                .AsNoTracking()
                .Where(c => c.Status == true);
        }

        public IQueryable<State> GetStatesForCountry(int id)
        {
            return context.States
                .AsNoTracking()
                .Include(s => s.Country)
                .Where(s => s.CountryID == id);
        }

        public IQueryable<City> GetCitiesForState(int id)
        {
            return context.Cities
                .AsNoTracking()
                .Include(c => c.State)
                .Where(c => c.StateID == id);
        }

        public IQueryable<Person> GetPeople()
        {
            return context.People
                .AsNoTracking();
        }

        public IQueryable<Person> GetPeopleWithLocations()
        {
            return context.People
                .AsNoTracking()
                .Include(p => p.Locations.Select(l => l.City))
                .Include(p => p.Locations.Select(l => l.State))
                .Include(p => p.Locations.Select(l => l.Country));
        }

        public Person GetPerson(int id)
        {
            return context.People
                .AsNoTracking()
                .FirstOrDefault(p => p.PersonID == id);
        }

        public Person GetPersonWithLocations(int id)
        {
            return context.People
              .AsNoTracking()
              .Include(p => p.Locations)
              .Include(p => p.Locations.Select(l => l.City))
              .Include(p => p.Locations.Select(l => l.State))
              .Include(p => p.Locations.Select(l => l.Country))
              .FirstOrDefault(p => p.PersonID == id);
        }

        public int InsertPerson(Person person)
        {
            context.People.Add(person);
            return context.SaveChanges();
        }

        public int UpdatePerson(Person person)
        {
            context.Entry(person).State = EntityState.Modified;

            foreach (var location in person.Locations)
            {
                context.Entry(location).State = EntityState.Modified;
            }

            return context.SaveChanges();
        }

        public IQueryable<Person> GetLocationsForPerson(int id)
        {
            return context.People
              .Include(p => p.Locations)
              .Include(p => p.Locations.Select(l => l.City))
              .Include(p => p.Locations.Select(l => l.State))
              .Include(p => p.Locations.Select(l => l.Country))
              .Where(p => p.PersonID == id);
        }

        public IQueryable<Location> GetLocations()
        {
            return context.Locations
                .Include(l => l.City)
                .Include(l => l.State)
                .Include(l => l.Country)
                .AsNoTracking();
        }

        public Location GetLocation(int id)
        {
            return context.Locations
                .Include(l => l.City)
                .Include(l => l.State)
                .Include(l => l.Country)
                .AsNoTracking()
                .FirstOrDefault(p => p.LocationID == id);
        }

        public IQueryable<Company> GetCompanies()
        {
            return context.Companies
                .AsNoTracking();
        }
    }
}
