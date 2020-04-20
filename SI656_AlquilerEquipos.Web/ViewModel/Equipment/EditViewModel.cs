using SI656_AlquilerEquipos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_AlquilerEquipos.Web.ViewModel.Equipment
{
    public class EditViewModel
    {
        public int Id { get; set; }
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
        public int EquipmentStateId { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
        [Required]
        [Display(Name = "Tipo de equipo")]
        public int EquipmentTypeId { get; set; }
        [Required]
        [Display(Name = "Precio por Hora")]
        public decimal PriceByHour { get; set; }
        [Required]
        [Display(Name = "Precio por dia")]
        public decimal PriceByDay { get; set; }
        [Required]
        [Display(Name = "Precio por semana")]
        public decimal PriceByWeek { get; set; }
        [Required]
        [Display(Name = "Hora extra")]
        public decimal ExtraHour { get; set; }
        [Required]
        [Display(Name = "Dia extra")]
        public decimal ExtraDay { get; set; }
        [Required]
        [Display(Name = "")]
        public string ImagePath { get; set; }


        public List<EquipmentState> StateList { get; set; }
        public List<EquipmentType> EquipmentTypes { get; set; }
    }
}