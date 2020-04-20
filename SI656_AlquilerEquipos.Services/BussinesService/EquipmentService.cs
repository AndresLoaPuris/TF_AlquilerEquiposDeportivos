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
    public class EquipmentService : IEquipmentService
    {
        private readonly EquipmentRepository _EquipmentRepository;
        public EquipmentService(db_AlquilerEquipoEntities context)
        {
            _EquipmentRepository = new EquipmentRepository(context);
        }

        public async Task AddEquipmentAsync(Equipment equipment)
        {
            await _EquipmentRepository.AddAsync(equipment);
            //throw new NotImplementedException();
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            await _EquipmentRepository.DeleteAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<List<Equipment>> GetAllEquipmentAsync()
        {
            var equipments = await _EquipmentRepository.ListAsync();
            //throw new NotImplementedException();
            return equipments;
        }

        public async Task<Equipment> GetByIdAsync(int id)
        {
            return await _EquipmentRepository.GetByIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task UpdateEquipmentAsync(Equipment equipment)
        {

            await _EquipmentRepository.EditAsync(equipment);
            //throw new NotImplementedException();
        }

        public async Task<List<EquipmentBasicInfoDTO>> GetEquipmentBasicInfoDTOsAsync()
        {
            return await _EquipmentRepository.GetAllAsync(EquipmentBasicInfoDTO.EquipmentSelector);
        }
    }
}
