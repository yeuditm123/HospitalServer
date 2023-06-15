using FluentScheduler;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace HospitalAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            JobManager.Initialize();

            JobManager.AddJob(
                () => {
                  var lSpam = ConfigurationManager.AppSettings["OpinionSpamWords"].Split(',');
                    string subject = ConfigurationManager.AppSettings["EmailUnapprovedOpinionSubject"];
                    string messege = string.Format(ConfigurationManager.AppSettings["EmailUnapprovedOpinionBody"],"");
                    Bl.OpinionBL.DeleteSpamOpinions(lSpam,subject,messege);
                },
                s => s.ToRunEvery(1).Minutes()
            );
        }
        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin", StringComparer.OrdinalIgnoreCase) &&
                Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
    }
}
