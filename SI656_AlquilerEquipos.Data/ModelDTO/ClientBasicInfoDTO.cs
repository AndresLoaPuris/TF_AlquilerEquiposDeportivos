using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Data.ModelDTO
{
    public class ClientBasicInfoDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }

        public static Expression<Func<Client, ClientBasicInfoDTO>> ClientSelector
        {
            get
            {
                return client => new ClientBasicInfoDTO()
                {
                    Id = client.Id,
                    FullName = client.Name + " " + client.FatherLastName + " " + client.MotherLastName,
                    Email = client.Email,
                    MobileNumber = client.MobileNumber,
                    Gender = client.Gender.Name
                };
            }
        }
    }
}
