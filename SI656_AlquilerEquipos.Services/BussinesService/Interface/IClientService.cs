using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService.Interface
{
    public interface IClientService
    {
        Task<Client> GetByIdAsync(int id);
        Task UpdateClientAsync(Client client);
        Task AddClientAsync(Client client);
        Task DeleteClientAsync(int id);
        Task<List<Client>> GetAllClientAsync();
        Task<List<ClientBasicInfoDTO>> GetClientListBasicInfoAsync();
        Task<List<Gender>> GetAllGenderAsync();
        Task<List<DocumentType>> GetAllDocumentTypeAsync();
    }
}
