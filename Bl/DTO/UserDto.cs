using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;


namespace Bl.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserImage { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Summary { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsAdmin { get; set; }
        public UserDto()
        {

        }
        public UserDto(Users u)
        {
            UserId = u.UserId;
            UserName = u.UserName;
            Email = u.Email;
            UserPassword = u.UserPassword;
            UserImage = u.UserImage;
            CreateDate = u.CreateDate;
            Summary = u.Summary;
            IsDisabled = u.IsDisabled;
            IsAdmin = u.IsAdmin;
        }

        
    }
    public static class UsersDtoExtensions
    {
        public static Users ToUsers(this UserDto userDto)
        {
            return new Users()
            {
                UserId = 0,
                UserName = userDto.UserName,
                Email = userDto.Email,
                UserPassword = userDto.UserPassword,
                UserImage = userDto.UserImage,
                CreateDate = userDto.CreateDate,
                Summary = userDto.Summary,
                IsDisabled = userDto.IsDisabled,
                IsAdmin =userDto.IsAdmin,
                Opinion = null
            };
        }
    }
    //public Users DtoToEntity(UserDto userDto)
    //{
    //    return new Users()
    //    {
    //        UserName = userDto.UserName,
    //        Email = userDto.Email,
    //        UserPassword = userDto.UserPassword,
    //        UserImage = userDto.UserImage,
    //        CreateDate = userDto.CreateDate,
    //        Summary = userDto.Summary,
    //        IsDisabled = userDto.IsDisabled,
    //        IsAdmin = userDto.IsAdmin
    //    };
}


