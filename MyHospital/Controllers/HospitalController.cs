using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyHospital.Controllers
{
    public class HospitalController : ApiController
    {
         Entities db = new Entities();
        // GET: api/Hospital

        public List<Hospitals> Get()
        {
            List<Hospitals> lst = new List<Hospitals>();
            foreach (var item in db.Hospital.ToList())
            {
                lst.Add(new Hospitals(item));
            }
            return lst;
        }

        // GET: api/Hospital/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hospital
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Hospital/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hospital/5
        public void Delete(int id)
        {
        }
        
    }
}
