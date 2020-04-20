using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess
{
    public class GenderRepository : BaseRepository<Gender> ,IGenderRepository
    {
        private readonly db_AlquilerEquipoEntities _context;

        public GenderRepository(db_AlquilerEquipoEntities context)
        {
            _context = context;
        }
    }
}
