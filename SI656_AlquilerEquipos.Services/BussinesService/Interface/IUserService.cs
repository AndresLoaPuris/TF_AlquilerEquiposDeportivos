using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService.Interface
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task UpdateUserAsync(User user);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<List<User>> GetAllUserAsync();
        Task<User> Authentication(string email, string password);
        Task<List<UserBasicInfoDTO>> GetUserListBasicInfoAsync();
    }
}
