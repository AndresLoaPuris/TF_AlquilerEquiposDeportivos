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

        public async Task AddClientAsync(cliente client)
        {
            await _clienteRepository.AddAsync(client);
            //throw new NotImplementedException();
        }

        public async Task DeleteClientAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<List<cliente>> GetAllClientAsync()
        {
            return await _clienteRepository.ListAsync();
            //throw new NotImplementedException();
        }

        public async Task<cliente> GetByIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task UpdateClientAsync(cliente client)
        {
            await _clienteRepository.EditAsync(client);
            //throw new NotImplementedException();
        }
    }
}
