using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bl;
using Bl.DTO;
using System.Configuration;

namespace HospitalAPI.Controllers
{
  
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {/// <summary>
    /// the function returns all the users
    /// </summary>
        [HttpGet]
        [Route("GetUsers")]
        public IHttpActionResult GetUsers()
        {
            return Ok(UsersBL.GetUsers());
        }
        /// <summary>
        /// the function checks if the user exists and return him
        /// </summary>
        [HttpGet]
        [Route("GetUser/{email}/{password}")]
        public IHttpActionResult GetUser([FromUri]string email, [FromUri] string password)
        {
           return Ok( UsersBL.LoginUser(email, password)); 
        }
        /// <summary>
        /// Sends an email if the user's opinion wad rejected
        /// </summary>
        [HttpGet]
        [Route("SendMail/{username}/{subject}/{messege}")]
        public IHttpActionResult SendMail(string username,string subject, string messege)
        {
            SendMailBL.ConfirmSendMail(username,subject, messege);
            return Ok();
        }

        [HttpGet]
        [Route("SendMailUnapprovedUsers/{username}/{summery}")]
        public IHttpActionResult SendMailUnapprovedUsers(string username, string summery)
        {
            string subject = ConfigurationManager.AppSettings["EmailUnapprovedOpinionSubject"];
            string messege =string.Format(ConfigurationManager.AppSettings["EmailUnapprovedOpinionBody"], summery);
            SendMailBL.ConfirmSendMail(username, subject, messege);
            return Ok(true);
        }

        /// <summary>
        /// the function adds the user to the user table
        /// </summary>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser(UserDto userDto)
        {
            return Ok(UsersBL.AddNewUser(userDto));
        }
       
        public void Delete(int id)
        {
        }
    }
}
