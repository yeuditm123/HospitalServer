using Bl;
using Bl.DTO;
using System.Collections.Generic;

using System.Web.Http;

namespace HospitalAPI.Controllers
{
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// function returns a object of department by departmentId
        /// </summary>
        [HttpGet]
        [Route("getDepartmentbyId/{id}")]
        public IHttpActionResult getDepartmentbyId(int id)
        {
            return Ok(DepartmentBL.GetDepartmentbyId(id));
        }

        [HttpPost]
        [Route("addNewDepartment")]
        public IHttpActionResult addNewDepartment(DepartmentDto newDep)
        {
            return Ok(DepartmentBL.AddNewDepartment(newDep));
        }

        [HttpPut]
        [Route("updateDepartment")]
         public IHttpActionResult updateDepartment(DepartmentDto depObj)
        {
            return Ok(DepartmentBL.UpdateDepartment(depObj));
        }

        // DELETE: api/Department/5
        public void Delete(int id)
        {
        }
    }
}
