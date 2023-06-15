using Bl.DTO;
using Dal;
using System;
using System.Linq;


namespace Bl
{
    public class DepartmentBL
    {
        static HospitalEntities db = new HospitalEntities();
        public static DepartmentDto GetDepartmentbyId(int depId)
        {
           // var count = db.Opinion.Count();
            var depObj = db.Departments.FirstOrDefault(d => d.DepartmentId == depId);
            if (depObj == null)
                return null;
            return GetDepartmentAvg(depObj);
        }
        public static DepartmentDto GetDepartmentAvg(Departments depObj)
        {
            
           var opinionList = db.Opinion.Where(x=>x.DepartmentId == 
           depObj.DepartmentId).ToList();

           var depObjDto = new DepartmentDto(depObj);
            if(opinionList.Any())
            {
                depObjDto.Rating1GeneralSatisfactionAvg = opinionList.Average(x => x.Rating1GeneralSatisfaction);
                depObjDto.Rating2ListenAndRelateAvg = opinionList.Average(x => x.Rating2ListenAndRelate);
                depObjDto.Rating3GettingHelpEasilyAvg = opinionList.Average(x => x.Rating3GettingHelpEasily);
                depObjDto.Rating4SharingInformationAvg = opinionList.Average(x => x.Rating4SharingInformation);
                depObjDto.Rating5AnEfficientProcessAvg = opinionList.Average(x => x.Rating5AnEfficientProcess);
                depObjDto.Rating6ConditionsOfHospitalizationAvg = opinionList.Average(x => x.Rating6ConditionsOfHospitalization);
                depObjDto.Rating7PreventionOfMedicalErrorsAvg = opinionList.Average(x => x.Rating7PreventionOfMedicalErrors);
            }
            depObjDto.Rating1GeneralSatisfactionAvg = Math.Round(depObjDto.Rating1GeneralSatisfactionAvg * 2, MidpointRounding.AwayFromZero) / 2;
            depObjDto.Rating1GeneralSatisfactionAvg = Math.Round(depObjDto.Rating1GeneralSatisfactionAvg * 2, MidpointRounding.AwayFromZero) / 2;
            depObjDto.Rating2ListenAndRelateAvg = Math.Round(depObjDto.Rating2ListenAndRelateAvg * 2, MidpointRounding.AwayFromZero) / 2;
            depObjDto.Rating3GettingHelpEasilyAvg = Math.Round(depObjDto.Rating3GettingHelpEasilyAvg * 2, MidpointRounding.AwayFromZero) / 2;
            depObjDto.Rating4SharingInformationAvg = Math.Round(depObjDto.Rating4SharingInformationAvg * 2, MidpointRounding.AwayFromZero) / 2;
            depObjDto.Rating5AnEfficientProcessAvg = Math.Round(depObjDto.Rating5AnEfficientProcessAvg * 2, MidpointRounding.AwayFromZero) / 2;
            depObjDto.Rating6ConditionsOfHospitalizationAvg = Math.Round(depObjDto.Rating6ConditionsOfHospitalizationAvg * 2, MidpointRounding.AwayFromZero) / 2;
            depObjDto.Rating7PreventionOfMedicalErrorsAvg = Math.Round(depObjDto.Rating7PreventionOfMedicalErrorsAvg * 2, MidpointRounding.AwayFromZero) / 2;
            return depObjDto;
        }
        public static DepartmentDto UpdateDepartment(DepartmentDto depObj)
        {
            var depUpdate = db.Departments.FirstOrDefault(d => d.DepartmentId == depObj.DepartmentId);
            if (depUpdate != null)
            {
              Departments department = depObj.ToDepartment();
              depUpdate.DepartmentId = department.DepartmentId;
              depUpdate.HospitalId = department.HospitalId;
              depUpdate.DepartmentTypeId = department.DepartmentTypeId;
              depUpdate.FullName = department.FullName;
              depUpdate.DepartmentUrl = department.DepartmentUrl;
              depUpdate.DepartmentManagerName = department.DepartmentManagerName;
              depUpdate.IsConfirmed = department.IsConfirmed;
              depUpdate.IsDeleted = department.IsDeleted;
              depUpdate.VisitTime = department.VisitTime;
              depUpdate.Tel = department.Tel;
            }
            db.SaveChanges();
            return new DepartmentDto(depUpdate);
        }
        public static DepartmentDto AddNewDepartment(DepartmentDto newDep)
        {
            Departments newAddDep = newDep.ToDepartment();
            db.Departments.Add(newAddDep);
            db.SaveChanges();
            return new DepartmentDto(newAddDep);
        }
    }
}
