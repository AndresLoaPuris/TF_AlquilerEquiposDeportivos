using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.Client
{
    public class EditViewModel
    {
        public int Id { get; set; }
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
        [Display(Name = "Genero")]
        public int GenderId { get; set; }
        [Required]
        [Display(Name = "Tipo de documento")]
        public int DocumentType { get; set; }
        [Required]
        [Display(Name = "Nro Documento")]
        public string DocumentNumber { get; set; }
        [Required]
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Numero de celular")]
        public string MobileNumber { get; set; }
        public List<DocumentType> DocumentTypes { get; set; }
        public List<Gender> GenderList { get; set; }
    }
}