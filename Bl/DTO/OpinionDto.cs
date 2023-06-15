using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.DTO
{
    public class OpinionDto
    {
        public int OpinionId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Rating1GeneralSatisfaction { get; set; }
        public int Rating2ListenAndRelate { get; set; }
        public int Rating3GettingHelpEasily { get; set; }
        public int Rating4SharingInformation { get; set; }
        public int Rating5AnEfficientProcess { get; set; }
        public int Rating6ConditionsOfHospitalization { get; set; }
        public int Rating7PreventionOfMedicalErrors { get; set; }
        public bool IsConfirmed { get; set; }
        public int? TotalRating { get; set; }
        public  UserDto Users { get; set; }
        public  DepartmentDto Departments { get; set; }
        public OpinionDto()
        {

        }
        public OpinionDto(Opinion o)
        {
            OpinionId = o.OpinionId;
            UserId = o.OpinionId;
            DepartmentId = o.DepartmentId;
            Title = o.Title;
            Summary = o.Summary;
            Rating1GeneralSatisfaction = o.Rating1GeneralSatisfaction;
            Rating2ListenAndRelate = o.Rating2ListenAndRelate;
            Rating3GettingHelpEasily = o.Rating3GettingHelpEasily;
            Rating4SharingInformation = o.Rating4SharingInformation;
            Rating5AnEfficientProcess = o.Rating5AnEfficientProcess;
            Rating6ConditionsOfHospitalization = o.Rating6ConditionsOfHospitalization;
            Rating7PreventionOfMedicalErrors = o.Rating7PreventionOfMedicalErrors;
            IsConfirmed = o.IsConfirmed;
            TotalRating = o.TotalRating;
            Users = o.Users!= null? new UserDto( o.Users): new UserDto();
            Departments = o.Departments!=null?
                new DepartmentDto(o.Departments): new DepartmentDto();  
        }
    }
    public class OpinionDtoPagination {
        public List<OpinionDto> Opinions { get; set; }
        public int Total { get; set; }
    }

    public static class OpinionDtoExtensions
    {
        public static Opinion ToOpinion(this OpinionDto opinionDto)
        {
            return new Opinion()
            {
                OpinionId = opinionDto.OpinionId,
                UserId = opinionDto.UserId,
                DepartmentId = opinionDto.DepartmentId,
                Title = opinionDto.Title,
                Summary = opinionDto.Summary,
                Rating1GeneralSatisfaction = opinionDto.Rating1GeneralSatisfaction,
                Rating2ListenAndRelate = opinionDto.Rating2ListenAndRelate,
                Rating3GettingHelpEasily = opinionDto.Rating3GettingHelpEasily,
                Rating4SharingInformation = opinionDto.Rating4SharingInformation,
                Rating5AnEfficientProcess = opinionDto.Rating5AnEfficientProcess,
                Rating6ConditionsOfHospitalization = opinionDto.Rating6ConditionsOfHospitalization,
                Rating7PreventionOfMedicalErrors = opinionDto.Rating7PreventionOfMedicalErrors,
                IsConfirmed = opinionDto.IsConfirmed,
                TotalRating = opinionDto.TotalRating,

            };
        }
    }
}

