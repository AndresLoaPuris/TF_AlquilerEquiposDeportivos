using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SI656_Alquiler_Equipos.Models
{
	public class UserLogin
	{
		public int Id { get; set; }
		[Required]
		[Display(Name = "Nombre de Usuario")]
		public string NameUser { get; set; }
		[Required]
		[Display(Name = "Contraseña")]
		public string Password { get; set; }
	}
}