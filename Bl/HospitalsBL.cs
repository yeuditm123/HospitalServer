using Bl.DTO;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Bl
{
   public class HospitalsBL
    {
        static HospitalEntities db = new HospitalEntities();
        public static List<HospitalDto> GetAllData()
        {
            List < HospitalDto > lst = new List<HospitalDto>();
            var hospitals = db.Hospitals.ToList();
            foreach (var item in hospitals.Where(x => x.IsConfirmed == true))
            {
                lst.Add(GetHospitalAvg(item));
            }
            return lst;
        }
        public static List<double> GetRating7ofHospitals(int code)
        {
            List<double> ls = new List<double>();
            var hospitals = db.Hospitals.Where(x => x.IsConfirmed == true).ToList();
            foreach (var item in hospitals)
            {
                var hospitalDto = new HospitalDto(item);
                hospitalDto= GetHospitalAvg(item);
                switch (code)
                {
                    case 1: ls.Add(hospitalDto.Rating1GeneralSatisfactionAvg); break;
                    case 2: ls.Add(hospitalDto.Rating2ListenAndRelateAvg); break;
                    case 3: ls.Add(hospitalDto.Rating3GettingHelpEasilyAvg); break;
                    case 4: ls.Add(hospitalDto.Rating4SharingInformationAvg); break;
                    case 5: ls.Add(hospitalDto.Rating5AnEfficientProcessAvg); break;
                    case 6: ls.Add(hospitalDto.Rating6ConditionsOfHospitalizationAvg); break;
                    case 7: ls.Add(hospitalDto.Rating7PreventionOfMedicalErrorsAvg); break;
                }
            }
            return ls;
        }
        public static HospitalDto GetHospitalAvg(Hospitals hospital) {
            var DepIds = db.Departments.Where(x=>x.HospitalId == hospital.HospitalId)
                            .Select(x => x.DepartmentId);
            var RatQuestions = db.Opinion.
                Where(r => DepIds.Contains(r.DepartmentId)).ToList();
            var hospitalDto = new HospitalDto(hospital);
            if (RatQuestions.Any())
            {
                hospitalDto.Rating1GeneralSatisfactionAvg = RatQuestions.Average(x => x.Rating1GeneralSatisfaction);
                hospitalDto.Rating2ListenAndRelateAvg = RatQuestions.Average(x => x.Rating2ListenAndRelate);
                hospitalDto.Rating3GettingHelpEasilyAvg = RatQuestions.Average(x => x.Rating3GettingHelpEasily);
                hospitalDto.Rating4SharingInformationAvg = RatQuestions.Average(x => x.Rating4SharingInformation);
                hospitalDto.Rating5AnEfficientProcessAvg = RatQuestions.Average(x => x.Rating5AnEfficientProcess);
                hospitalDto.Rating6ConditionsOfHospitalizationAvg = RatQuestions.Average(x => x.Rating6ConditionsOfHospitalization);
                hospitalDto.Rating7PreventionOfMedicalErrorsAvg = RatQuestions.Average(x => x.Rating7PreventionOfMedicalErrors);
                hospitalDto.TotalRatingAvg = (hospitalDto.Rating1GeneralSatisfactionAvg + hospitalDto.Rating2ListenAndRelateAvg +
                    hospitalDto.Rating3GettingHelpEasilyAvg + hospitalDto.Rating4SharingInformationAvg +
                    hospitalDto.Rating5AnEfficientProcessAvg +
                    hospitalDto.Rating6ConditionsOfHospitalizationAvg + hospitalDto.Rating7PreventionOfMedicalErrorsAvg) / 7;

            }
            hospitalDto.Rating1GeneralSatisfactionAvg = Math.Round(hospitalDto.Rating1GeneralSatisfactionAvg * 2, MidpointRounding.AwayFromZero) / 2;
            hospitalDto.Rating2ListenAndRelateAvg = Math.Round(hospitalDto.Rating2ListenAndRelateAvg * 2, MidpointRounding.AwayFromZero) / 2;
            hospitalDto.Rating3GettingHelpEasilyAvg = Math.Round(hospitalDto.Rating3GettingHelpEasilyAvg * 2, MidpointRounding.AwayFromZero) / 2;
            hospitalDto.Rating4SharingInformationAvg = Math.Round(hospitalDto.Rating4SharingInformationAvg * 2, MidpointRounding.AwayFromZero) / 2;
            hospitalDto.Rating5AnEfficientProcessAvg = Math.Round(hospitalDto.Rating5AnEfficientProcessAvg * 2, MidpointRounding.AwayFromZero) / 2;
            hospitalDto.Rating6ConditionsOfHospitalizationAvg = Math.Round(hospitalDto.Rating6ConditionsOfHospitalizationAvg * 2, MidpointRounding.AwayFromZero) / 2;
            hospitalDto.Rating7PreventionOfMedicalErrorsAvg = Math.Round(hospitalDto.Rating7PreventionOfMedicalErrorsAvg * 2, MidpointRounding.AwayFromZero) / 2;
            hospitalDto.TotalRatingAvg = Math.Round(hospitalDto.TotalRatingAvg*2, MidpointRounding.AwayFromZero) / 2;
            return hospitalDto;
        }
        public static List<HospitalDto> GetHospitals()
        {
            List<HospitalDto> ls = new List<HospitalDto>();
            var h = db.Hospitals.ToList();
            foreach (var item in h)
            {
                ls.Add(new HospitalDto(item));
            }
            return ls;
        }

        public static void SaveImage(int id, string fileName)
        {
            var hospital = db.Hospitals.Where(c => c.HospitalId == id).SingleOrDefault();
            if (String.IsNullOrEmpty(hospital.HosImage))
            {
                hospital.HosImage = fileName;
            }
            else {
                hospital.HosImage += ","+fileName;
            }
            db.SaveChanges();
        }

        public static List<DepartmentDto> GetDepartmentByHospitalId(int id)
        {
            List<DepartmentDto> lst = new List<DepartmentDto>();
            var hospitals = db.Hospitals.Include("Departments").ToList();
            foreach (var item in hospitals)
            {
                if (item.HospitalId == id)
                {
                    foreach (var item1 in item.Departments.Where(x=>x.IsConfirmed==true).ToList())
                    {
                        lst.Add(new DepartmentDto(item1));
                    }
                }
            }
            return lst;
        }
        public static HospitalDto GetHospitalById(int id)
        {
            var hospital = db.Hospitals.Include("Departments").FirstOrDefault(h => h.HospitalId == id);
            if (hospital == null)
                return null;
            return GetHospitalAvg(hospital);
            
        }
        public static HospitalDto UpdateHospital(HospitalDto hosObj)
         {
             var hospital = db.Hospitals.FirstOrDefault(h => h.HospitalId == hosObj.HospitalId);
             if (hospital!=null)
             {
                Hospitals h = hosObj.ToHospital();
                hospital.HospitalId = h.HospitalId;
                hospital.HospitalName = h.HospitalName;
                hospital.UrlAddress = h.UrlAddress;
                hospital.IsConfirmed = h.IsConfirmed;
                hospital.Tel = h.Tel;
                hospital.HosImage = h.HosImage;
                hospital.HospitalAddress = h.HospitalAddress;
               
             }
            db.SaveChanges();
           
            return new HospitalDto(hospital);
         }
        public static HospitalDto addnewHospital(HospitalDto hospital)
        {
            Hospitals newHospital = hospital.ToHospital();
            db.Hospitals.Add(newHospital);
            db.SaveChanges();
            return new HospitalDto(newHospital);
        }
    }
}
