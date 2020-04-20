using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Data.ModelDTO;
using SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(db_AlquilerEquipoEntities context)
        {
            _userRepository = new UserRepository(context);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            //throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _userRepository.ListAsync();
            //throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.EditAsync(user);
            //throw new NotImplementedException();
        }

        public async Task<User> Authentication(string email, string password)
        {
            return await _userRepository.Authentication(email, password);
        }

        public async Task<List<UserBasicInfoDTO>> GetUserListBasicInfoAsync()
        {
            return await _userRepository.GetAllAsync(UserBasicInfoDTO.UserSelector);
        }
    }
}
