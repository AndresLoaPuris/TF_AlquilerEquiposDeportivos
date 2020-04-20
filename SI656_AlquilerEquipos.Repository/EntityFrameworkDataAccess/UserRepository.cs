using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly db_AlquilerEquipoEntities _context;

        public UserRepository(db_AlquilerEquipoEntities context)
        {
            _context = context;
        }

        public async Task<User> Authentication(string email, string password)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
                return user;
            }
            catch (Exception e) {
                return null;
            }
            //throw new NotImplementedException();
        }
    }
}
