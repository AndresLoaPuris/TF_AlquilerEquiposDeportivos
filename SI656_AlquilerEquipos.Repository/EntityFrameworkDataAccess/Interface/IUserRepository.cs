﻿using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Repository.EntityFrameworkDataAccess.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Authentication(string email, string password);
    }
}
