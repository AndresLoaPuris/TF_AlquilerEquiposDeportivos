using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService.Interface
{
    public interface IEquipmentService
    {
        Task<Equipment> GetByIdAsync(int id);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task AddEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);
        Task<List<Equipment>> GetAllEquipmentAsync();
        Task<List<EquipmentBasicInfoDTO>> GetEquipmentBasicInfoDTOsAsync();
    }
}
