using Core.Domain.IRepositories;
using Core.DTO.Factory;
using System.Web.Http;

namespace Core.API.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly IRepository repository;

        LocationFactory locationFactory;
        PersonFactory personFactory;
        CityFactory cityFactory;
        StateFactory stateFactory;
        CountryFactory countryFactory;

        public const int maxPageSize = 100;
        public BaseApiController(IRepository repoParam)
        {
            repository = repoParam;
        }

        protected IRepository Repository
        {
            get
            {
                return repository;
            }
        }
        protected LocationFactory LocationFactory
        {
            get
            {
                if (locationFactory == null)
                {
                    locationFactory = new LocationFactory();
                }
                return locationFactory;
            }
        }
        protected PersonFactory PersonFactory
        {
            get
            {
                if (personFactory == null)
                {
                    personFactory = new PersonFactory();
                }
                return personFactory;
            }
        }

        protected CityFactory CityFactory
        {
            get
            {
                if (cityFactory == null)
                {
                    cityFactory = new CityFactory();
                }
                return cityFactory;
            }
        }

        protected StateFactory StateFactory
        {
            get
            {
                if (stateFactory == null)
                {
                    stateFactory = new StateFactory();
                }
                return stateFactory;
            }
        }

        protected CountryFactory CountryFactory
        {
            get
            {
                if (countryFactory == null)
                {
                    countryFactory = new CountryFactory();
                }
                return countryFactory;
            }
        }
    }
}
