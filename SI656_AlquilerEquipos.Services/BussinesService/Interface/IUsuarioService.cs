using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService.Interface
{
    public interface IUsuarioService
    {
        Task<usuario> GetByIdAsync(int id);
        Task UpdateUserAsync(usuario user);
        Task AddUserAsync(usuario user);
        Task DeleteUserAsync(int id);
        Task<List<usuario>> GetAllUserAsync();
    }
}
