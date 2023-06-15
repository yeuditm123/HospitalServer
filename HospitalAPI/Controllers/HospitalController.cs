using Bl.DTO;
using System;
using System.Web.Http;
using Bl;
using System.Web;

namespace HospitalAPI.Controllers
{
    [RoutePrefix("api/Hospital")]
    public class HospitalController : ApiController
    {
        /// <summary>
        /// the function returns a list of all hospitals and their departments
        /// </summary>

        [HttpGet]
        [Route("GetAllData")]
        public IHttpActionResult GetAllData()
        {
            return Ok(HospitalsBL.GetAllData());
        }
        /// <summary>
        /// the function returns a list of all hospitals
        /// </summary>

        [HttpGet]
        [Route("GetHospitals")]
        public IHttpActionResult GetHospitals()
        {
            return Ok(HospitalsBL.GetHospitals());
        }
        /// <summary>
        /// the function returns a list of all departments Of the given hospital
        /// </summary>
        [HttpGet]
        [Route("GetDepartmentByHospitalId/{id}")]
        public IHttpActionResult GetDepartmentByHospitalId(int id)
        {
            return Ok(HospitalsBL.GetDepartmentByHospitalId(id));
        }
        /// <summary>
        /// the function returns a hospital by id
        /// </summary>
        [HttpGet]
        [Route("GetHospitalById/{id}")]
        public IHttpActionResult GetHospitalById(int id)
        {
            return Ok(HospitalsBL.GetHospitalById(id));
        }
        [HttpGet]
        [Route("GetRating7ofHospitals/{selectedTypeQuestion}")]
        public IHttpActionResult GetRating7ofHospitals(int selectedTypeQuestion)
        {
            return Ok(HospitalsBL.GetRating7ofHospitals(selectedTypeQuestion));
        }

        /// <summary>
        /// A function that adds an image for a hospital or for a user profile image .And also updates the assets folder in angular
        ///
        /// </summary>
        [HttpPost]
        [Route("Upload/{id}")]
        public IHttpActionResult SaveImage(int id)
        {
            var myFile = HttpContext.Current.Request.Files[0];
            var ext = myFile.FileName.Split('.')[1];
            string fileName = Guid.NewGuid() + "." + ext;
            if (myFile != null && myFile.ContentLength != 0)
            {
                string fullPath = AppDomain.CurrentDomain.BaseDirectory;

                fullPath = fullPath.Remove(fullPath.LastIndexOf('\\'));
                fullPath = fullPath.Remove(fullPath.LastIndexOf('\\'));
                fullPath = fullPath.Remove(fullPath.LastIndexOf('\\'));
                fullPath += @"\HospitalClient\src\assets\images\" + fileName;
                myFile.SaveAs(fullPath);
            }
            HospitalsBL.SaveImage(id, fileName);
            return Ok();
        }

        [HttpPost]
        [Route("addnewHospital")]
         public IHttpActionResult addnewHospital(HospitalDto hospitalDto)
        {
            return Ok(HospitalsBL.addnewHospital(hospitalDto));
        }

        [HttpPut]
        [Route("UpdateHospital")]
       public IHttpActionResult UpdateHospital(HospitalDto hosObj)
        {
            return Ok(HospitalsBL.UpdateHospital(hosObj));
        }

        // DELETE: api/Hospital/5
        public void Delete(int id)
        {
        }
    }
    
}
