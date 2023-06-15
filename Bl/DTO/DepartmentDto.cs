using Dal;
using System.Collections.Generic;


namespace Bl.DTO
{
   public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public int HospitalId { get; set; }
        public int? DepartmentTypeId { get; set; }
        public string FullName { get; set; }
        public string DepartmentUrl { get; set; }
        public string DepartmentManagerName { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public string VisitTime { get; set; }
        public string Tel { get; set; }
        public double Rating1GeneralSatisfactionAvg { get; set; }
        public double Rating2ListenAndRelateAvg { get; set; }
        public double Rating3GettingHelpEasilyAvg { get; set; }
        public double Rating4SharingInformationAvg { get; set; }
        public double Rating5AnEfficientProcessAvg { get; set; }
        public double Rating6ConditionsOfHospitalizationAvg { get; set; }
        public double Rating7PreventionOfMedicalErrorsAvg { get; set; }
        public List<OpinionDto> Opinion { get; set; }
        public DepartmentDto()
        {

        }
        public DepartmentDto(Departments d)
        {
            DepartmentId = d.DepartmentId;
            HospitalId = d.HospitalId;
            DepartmentTypeId = d.DepartmentTypeId;
            FullName = d.FullName;
            DepartmentUrl = d.DepartmentUrl;
            DepartmentManagerName = d.DepartmentManagerName;
            IsConfirmed = d.IsConfirmed;
            IsDeleted = d.IsDeleted;
            VisitTime= d.VisitTime;
            Tel = d.Tel;
           
            //Opinion =d.Opinion!= null?
            //   d.Opinion.Select(x => new OpinionDto(x)).ToList():new List<OpinionDto>();
        }
    }
    public static class DepartmentDtoExtensions
    {
        public static Departments ToDepartment(this DepartmentDto departmentDto)
        {
            return new Departments()
            {
                DepartmentId = departmentDto.DepartmentId,
                HospitalId = departmentDto.HospitalId,
                DepartmentTypeId = departmentDto.DepartmentTypeId,
                FullName = departmentDto.FullName,
                DepartmentUrl = departmentDto.DepartmentUrl,
                DepartmentManagerName = departmentDto.DepartmentManagerName,
                IsConfirmed = departmentDto.IsConfirmed,
                IsDeleted = departmentDto.IsDeleted,
                VisitTime = departmentDto.VisitTime,
                Tel = departmentDto.Tel,
                Opinion = null,
            };
        }
    }
}
