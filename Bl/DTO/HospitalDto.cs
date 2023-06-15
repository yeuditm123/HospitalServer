using Dal;
using System.Collections.Generic;
using System.Linq;


namespace Bl.DTO
{
   public class HospitalDto
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string UrlAddress { get; set; }
        public bool IsConfirmed { get; set; }
        public string Tel { get; set; }
        public string HosImage { get; set; }
        public string HospitalAddress { get; set; }
        public double Rating1GeneralSatisfactionAvg { get; set; }
        public double Rating2ListenAndRelateAvg { get; set; }
        public double Rating3GettingHelpEasilyAvg { get; set; }
        public double Rating4SharingInformationAvg { get; set; }
        public double Rating5AnEfficientProcessAvg { get; set; }
        public double Rating6ConditionsOfHospitalizationAvg { get; set; }
        public double Rating7PreventionOfMedicalErrorsAvg { get; set; }
        public double TotalRatingAvg { get; set; }
        public List<DepartmentDto> Departments { get; set; }
        public HospitalDto()
        {

        }
        public HospitalDto(Hospitals h)
        {
            HospitalId = h.HospitalId;
            HospitalName = h.HospitalName;
            UrlAddress = h.UrlAddress;
            IsConfirmed = h.IsConfirmed;
            Tel = h.Tel;
            HosImage = h.HosImage;
            HospitalAddress = h.HospitalAddress;
            Departments = h.Departments!= null?
                h.Departments.Select(x=> new DepartmentDto(x)).ToList():  new List<DepartmentDto>();
        }
    }
    public static class HospitalDtoExtensions
    {
        public static Hospitals ToHospital(this HospitalDto hospitalDto)
        {
            return new Hospitals()
            {

                HospitalId = hospitalDto.HospitalId,
                HospitalName = hospitalDto.HospitalName,
                UrlAddress = hospitalDto.UrlAddress,
                IsConfirmed = hospitalDto.IsConfirmed,
                Tel = hospitalDto.Tel,
                HosImage = hospitalDto.HosImage,
                HospitalAddress = hospitalDto.HospitalAddress,

            };
        }
    }
}
