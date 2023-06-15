using Bl.DTO;
using Dal;
using System.Collections.Generic;
using System.Linq;

namespace Bl
{
   public class UsersBL
    {
        static HospitalEntities db = new HospitalEntities();
        public static UserDto LoginUser(string email, string password) {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.UserPassword == password);
            if (user == null)
                return null;
            return new UserDto(user);
        }

        public static UserDto AddNewUser(UserDto userDto)
       {
            Users user = userDto.ToUsers();
            db.Users.Add(user);
            db.SaveChanges();
            return new UserDto(user);
        }
        public static List<UserDto> GetUsers()
        {
            List<UserDto> userLst = new List<UserDto>();
            var users = db.Users.ToList();
            foreach (var item in users)
            {
                userLst.Add(new UserDto(item));
            }
            return userLst;
        }

    }
}
