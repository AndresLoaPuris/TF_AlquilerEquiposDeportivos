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

        public Task AddUserAsync(usuario user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<usuario>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<usuario> GetByIdAsync(int idd)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
