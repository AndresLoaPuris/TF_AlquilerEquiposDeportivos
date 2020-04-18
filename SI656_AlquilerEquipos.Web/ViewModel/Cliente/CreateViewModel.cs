using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.Cliente
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Tipo de documento")]
        public int DocumentType { get; set; }
        [Required]
        [Display(Name = "Nro Documento")]
        public string DocumentNumber { get; set; }
        public List<tipo_documento> DocumentTypes { get; set; }
    }
}