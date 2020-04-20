using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.User
{
    public class CreateViewModel
    {

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string FatherLastName { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string MotherLastName { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string NameUser { get; set; }
        [Required]
        [Display(Name = "Clave")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Cargo")]
        public int RolId { get; set; }
        [Required]
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string MobileNumber { get; set; }

        public List<Rol> RolList { get; set; }
    }
}