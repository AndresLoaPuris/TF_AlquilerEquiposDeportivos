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

        public async Task AddEquipmentAsync(equipo equipment)
        {
            await _equipoRepository.AddAsync(equipment);
            //throw new NotImplementedException();
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            await _equipoRepository.DeleteAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<List<equipo>> GetAllEquipmentAsync()
        {
            var equipments = await _equipoRepository.ListAsync();
            //throw new NotImplementedException();
            return equipments;
        }

        public async Task<equipo> GetByIdAsync(int id)
        {
            return await _equipoRepository.GetByIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task UpdateEquipmentAsync(equipo equipment)
        {
            await _equipoRepository.EditAsync(equipment);
            //throw new NotImplementedException();
        }
    }
}
