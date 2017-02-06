//using Core.Domain;
//using Core.Domain.IRepositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Http;

//namespace Core.API.Controllers
//{
//    [RoutePrefix("api")]
//    public class CompaniesController : BaseApiController
//    {
//        public CompaniesController(IRepository repoParam) : base(repoParam)
//        {
//        }


//        [Route("companies", Name = "CompanyList")]
//        public IHttpActionResult Get()
//        {
//            try
//            {
//                IEnumerable<Company> company = Repository.GetCompanies().ToList();
//                return Ok(company.ToList().OrderBy(c => c.CompanyID).Select(c => Factory.Create(c)));
//            }
//            catch (Exception)
//            {
//                return InternalServerError();
//            }
//        }
//    }
//}
