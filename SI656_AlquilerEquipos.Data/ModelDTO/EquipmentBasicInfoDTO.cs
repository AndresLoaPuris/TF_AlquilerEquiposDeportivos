using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Data.ModelDTO
{
    public class EquipmentBasicInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string EquipmentType { get; set; }
        public string State { get; set; }

        public static Expression<Func<Equipment, EquipmentBasicInfoDTO>> EquipmentSelector
        {
            get
            {
                return equipment => new EquipmentBasicInfoDTO()
                {
                    Id = equipment.Id,
                    Name = equipment.Name,
                    Stock = equipment.Stock,
                    EquipmentType = equipment.EquipmentType.Name,
                    State = equipment.EquipmentState.Name
                };
            }
        }
    }
}
