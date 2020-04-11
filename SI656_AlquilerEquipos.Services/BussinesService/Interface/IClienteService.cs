using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService.Interface
{
    public interface IClienteService
    {
        Task<cliente> GetByIdAsync(int id);
        Task UpdateClientAsync(cliente client);
        Task AddClientAsync(cliente client);
        Task DeleteClientAsync(int id);
        Task<List<cliente>> GetAllClientAsync();
    }
}
