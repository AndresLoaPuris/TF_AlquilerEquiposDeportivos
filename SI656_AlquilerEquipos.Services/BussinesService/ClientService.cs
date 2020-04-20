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
    public class ClientService : IClientService
    {
        private readonly ClientRepository _ClientRepository;
        private readonly GenderRepository _genderRepository;
        private readonly DocumentTypeRepository _documentTypeRepository;
        public ClientService(db_AlquilerEquipoEntities context)
        {
            _ClientRepository = new ClientRepository(context);
            _genderRepository = new GenderRepository(context);
            _documentTypeRepository = new DocumentTypeRepository(context);
        }

        public async Task AddClientAsync(Client client)
        {
            await _ClientRepository.AddAsync(client);
            //throw new NotImplementedException();
        }

        public async Task DeleteClientAsync(int id)
        {
            await _ClientRepository.DeleteAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<List<Client>> GetAllClientAsync()
        {
            return await _ClientRepository.ListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _ClientRepository.GetByIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _ClientRepository.EditAsync(client);
            //throw new NotImplementedException();
        }

        public async Task<List<ClientBasicInfoDTO>> GetClientListBasicInfoAsync()
        {
            return await _ClientRepository.GetAllAsync(ClientBasicInfoDTO.ClientSelector);
        }

        public async Task<List<Gender>> GetAllGenderAsync()
        {
            return await _genderRepository.ListAsync();
            //throw new NotImplementedException();
        }

        public async Task<List<DocumentType>> GetAllDocumentTypeAsync()
        {
            return await _documentTypeRepository.ListAsync();
            //throw new NotImplementedException();
        }
    }
}
