using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.Equipo
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Codigo")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Costo")]
        public decimal Cost { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public int StateType { get; set; }

        public List<estado> StateList { get; set; }
    }
}