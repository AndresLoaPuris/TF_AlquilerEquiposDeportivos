using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Data.ModelDTO
{
    public class UserBasicInfoDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string MobileNumber { get; set; }

        public static Expression<Func<User, UserBasicInfoDTO>> UserSelector
        {
            get
            {
                return user => new UserBasicInfoDTO()
                {
                    Id = user.Id,
                    UserName = user.NameUser,
                    Email = user.Email,
                    Rol = user.Rol.Name,
                    MobileNumber = user.MobileNumber
                };
            }
        }

    }
}
