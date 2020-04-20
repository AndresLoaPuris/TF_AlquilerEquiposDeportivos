using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.Client
{
    public class IndexViewModel
    {
        public List<ClientBasicInfoDTO> ClientList { get; set; }
    }
}