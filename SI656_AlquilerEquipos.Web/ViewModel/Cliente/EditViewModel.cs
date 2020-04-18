using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.Cliente
{
    public class EditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Genero")]
        public string Gender { get; set; }
        [Display(Name = "Tipo de documento")]
        public int DocumentType { get; set; }
        [Display(Name = "Nro Documento")]
        public string DocumentNumber { get; set; }
        public List<tipo_documento> DocumentTypes { get; set; }
    }
}