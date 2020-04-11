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
    public class EquipoService : IEquipoService
    {
        private readonly EquipoRepository _equipoRepository;
        public EquipoService(db_AlquilerEquipoEntities context)
        {
            _equipoRepository = new EquipoRepository(context);
        }

        public Task AddEquipmentAsync(equipo equipment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEquipmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<equipo>> GetAllEquipmentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<equipo> GetByIdAsync(int idd)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEquipmentAsync(equipo equipment)
        {
            throw new NotImplementedException();
        }
    }
}
