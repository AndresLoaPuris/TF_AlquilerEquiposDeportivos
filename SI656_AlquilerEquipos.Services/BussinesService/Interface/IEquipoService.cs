using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Services.BussinesService.Interface
{
    public interface IEquipoService
    {
        Task<equipo> GetByIdAsync(int idd);
        Task UpdateEquipmentAsync(equipo equipment);
        Task AddEquipmentAsync(equipo equipment);
        Task DeleteEquipmentAsync(int id);
        Task<List<equipo>> GetAllEquipmentAsync();
    }
}
