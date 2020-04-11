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
    public class ClienteService : IClienteService
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteService(db_AlquilerEquipoEntities context)
        {
            _clienteRepository = new ClienteRepository(context);
        }

        public Task AddClientAsync(cliente client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<equipo>> GetAllClientAsync()
        {
            throw new NotImplementedException();
        }

        public Task<cliente> GetByIdAsync(int idd)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClientAsync(cliente client)
        {
            throw new NotImplementedException();
        }
    }
}
