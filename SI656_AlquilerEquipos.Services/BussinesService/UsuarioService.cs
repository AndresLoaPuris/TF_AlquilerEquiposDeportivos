using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _userRepository;
        public UsuarioService(db_AlquilerEquipoEntities context)
        {
            _userRepository = new UsuarioRepository(context);
        }

        public async Task AddUserAsync(usuario user)
        {
            await _userRepository.AddAsync(user);
            //throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<List<usuario>> GetAllUserAsync()
        {
            return await _userRepository.ListAsync();
            //throw new NotImplementedException();
        }

        public async Task<usuario> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(usuario user)
        {
            await _userRepository.EditAsync(user);
            //throw new NotImplementedException();
        }
    }
}
