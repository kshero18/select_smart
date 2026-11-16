using SelectSmart.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace ASPCoreWithAngular.Controllers
{
    public class CandidateController : Controller
    {
        candidateDataAccessLayer objcandidate = new candidateDataAccessLayer();
        [HttpGet]
        [Route("api/candidate/Index")]
        public IEnumerable<candidate> Index()
        {
            return objcandidate.GetAllCandidate();
        }
        [HttpPost]
        [Route("api/candidate/Create")]
        public int Create([FromBody] candidate candidate)
        {
            return objcandidate.AddCandidate(candidate);
        }
        [HttpGet]
        [Route("api/candidate/Details/{id}")]
        public candidate Details(int id)
        {
            return objcandidate.GetCandidateData(id);
        }
        [HttpPut]
        [Route("api/candidate/Edit")]
        public int Edit([FromBody]candidate candidate)
        {
            return objcandidate.UpdateCandidate(candidate);
        }
        [HttpDelete]
        [Route("api/candidate/Delete/{id}")]
        public int Delete(int id)
        {
            return objcandidate.DeleteCandidate(id);
        }
    }
}