using Bl;
using Bl.DTO;
using System.Collections.Generic;

using System.Web.Http;

namespace HospitalAPI.Controllers
{
    [RoutePrefix("api/Opinion")]
    public class OpinionController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
   /// <summary>
   /// function returns all the hospital's opinions
   /// </summary>
       [HttpGet]
       [Route("getAllOpinionByHospital/{id}/{pageSize}/{pageIndex}")]
        public IHttpActionResult getAllOpinionByHospital(int id,int pageSize,int pageIndex)
        {
            return Ok(OpinionBL.getOpinionsPagination(id,pageSize,pageIndex));
        }
        /// <summary>
        /// function returns all the department's opinions
        /// </summary>
        [HttpGet]
        [Route("getAllOpinionByDepId/{depId}/{pageSize}/{pageIndex}")]
        public IHttpActionResult getAllOpinionByDepId(int depId, int pageSize, int pageIndex)
        {
            return Ok(OpinionBL.getAllOpinionByDepId(depId, pageSize, pageIndex));
        }

        [HttpGet]
        [Route("getallOpinion/{pageSize}/{pageIndex}")]
        public IHttpActionResult getallOpinion(int pageSize,int pageIndex)
        {
            return Ok(OpinionBL.getallOpinion(pageSize,pageIndex));
        }

        /// <summary>
        /// A function that adds a user opinion for a particular department
        /// </summary>
        [HttpPost]
        [Route("AddNewOpinion")]
        public IHttpActionResult AddNewOpinion(OpinionDto opinion)
        {
            return Ok(OpinionBL.AddNewOpinion(opinion));
        }

        [HttpPut]
        [Route("updateisConfirmedOfOpinion")]
        public IHttpActionResult updateisConfirmedOfOpinion(OpinionDto opinion)
        {
            return Ok(OpinionBL.updateOpinion(opinion));
        }
        // DELETE: api/Opinion/5
        public void Delete(int id)
        {
        }
    }
}
