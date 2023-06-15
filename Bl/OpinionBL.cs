using Bl.DTO;
using Dal;
using System.Collections.Generic;
using System.Linq;


namespace Bl
{
    public class OpinionBL
    {
        static HospitalEntities db = new HospitalEntities();
        public static OpinionDto AddNewOpinion(OpinionDto opinion)
        {
            Opinion newOpinion = opinion.ToOpinion();
            db.Opinion.Add(newOpinion);
            db.SaveChanges();
            return new OpinionDto(newOpinion);
        }

        public static void DeleteSpamOpinions(string[] lSpam, string subject,string messege)
        {
            var opinions = db.Opinion.Where(z => z.IsConfirmed == true &&
            (lSpam.Any(x => z.Title.Contains(x)) || lSpam.Any(x => z.Summary.Contains(x))));
            foreach (var opinion in opinions)
            {
                opinion.IsConfirmed = false;
                SendMailBL.ConfirmSendMail(opinion.Users.Email, subject,string.Format(messege,opinion.Summary));
            }
            db.SaveChanges();
        }
        /*public static List<OpinionDto> getOpinionAll(int hospitalId)
{
   var hospital = db.Hospitals.Include("Departments").FirstOrDefault(h => h.HospitalId == hospitalId);
   var departmentsId = hospital.Departments.Select(d => d.DepartmentId);
   List<OpinionDto> lst = new List<OpinionDto>();
   var opinionList = db.Opinion.Include("Users")
       .Where(o => departmentsId.Contains(o.DepartmentId)).ToList();
   foreach (var item in opinionList)
   {
       lst.Add(new OpinionDto(item));
   }
   return lst;
}*/
        public static OpinionDtoPagination getOpinionsPagination(int hospitalId,int pageSize, int pageIndex)
        {
            var hospital = db.Hospitals.Include("Departments").FirstOrDefault(h => h.HospitalId == hospitalId);
            var departmentsId = hospital.Departments.Select(d => d.DepartmentId);
            List<OpinionDto> lst = new List<OpinionDto>();
            var total = db.Opinion.Where(x => x.IsConfirmed == true).Count(o => departmentsId.Contains(o.DepartmentId));
            var opinionList = db.Opinion.Include("Users")
                .Where(o => departmentsId.Contains(o.DepartmentId)&& o.IsConfirmed == true).OrderByDescending(x=>x.OpinionId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            foreach (var item in opinionList)
            {
                lst.Add(new OpinionDto(item));
            }
            return new OpinionDtoPagination() { Opinions = lst, Total = total};
        }
      

        public static OpinionDtoPagination getAllOpinionByDepId(int depId,int pageSize, int pageIndex)
        {
            List<OpinionDto> ls = new List<OpinionDto>();
            var total = db.Opinion.Where(x => x.IsConfirmed == true).Count(d => d.DepartmentId == depId);
            var opinions = db.Opinion.Include("Users").Where(d => d.DepartmentId == depId&& d.IsConfirmed == true).OrderByDescending(x=>x.OpinionId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            foreach (var item in opinions)
            {
                ls.Add(new OpinionDto(item));
            }
            return new OpinionDtoPagination() { Opinions=ls,Total=total};
        }
        public static OpinionDtoPagination getallOpinion(int pageSize, int pageIndex)
        { 
            List<OpinionDto> lstOpinion = new List<OpinionDto>();
            var total = db.Opinion.Where(x=>x.IsConfirmed==true).Count();
            pageIndex++;
            var opinions = db.Opinion.Include("Users").Where(x => x.IsConfirmed == true).OrderByDescending(x=>x.OpinionId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            foreach (var item in opinions)
            {
                lstOpinion.Add(new OpinionDto(item));
            }
            return new OpinionDtoPagination() { Opinions=lstOpinion,Total=total};
        }
        public static OpinionDto updateOpinion(OpinionDto opinion)
        {
            var op = db.Opinion.FirstOrDefault(x => x.OpinionId == opinion.OpinionId);
            if(op!=null)
            {
                Opinion opinionObj = opinion.ToOpinion();
                op.OpinionId = opinionObj.OpinionId;
                op.DepartmentId = opinionObj.DepartmentId;
                op.Title = opinionObj.Title;
                op.Summary = opinionObj.Summary;
                op.Rating1GeneralSatisfaction = opinionObj.Rating1GeneralSatisfaction;
                op.Rating2ListenAndRelate = opinionObj.Rating2ListenAndRelate;
                op.Rating3GettingHelpEasily = opinionObj.Rating3GettingHelpEasily;
                op.Rating4SharingInformation = opinionObj.Rating4SharingInformation;
                op.Rating5AnEfficientProcess = opinionObj.Rating5AnEfficientProcess;
                op.Rating6ConditionsOfHospitalization = opinionObj.Rating6ConditionsOfHospitalization;
                op.Rating7PreventionOfMedicalErrors = opinionObj.Rating7PreventionOfMedicalErrors;
                op.IsConfirmed = opinionObj.IsConfirmed;
                op.TotalRating = opinionObj.TotalRating;
            }
            db.SaveChanges();
            return new OpinionDto(op);
        }
    }
   
}
