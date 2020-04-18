using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.Usuario
{
    public class EditViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string User { get; set; }
        [Required]
        [Display(Name = "Clave")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Cargo")]
        public int Rol { get; set; }

        public List<cargo> RolList { get; set; }
    }
}