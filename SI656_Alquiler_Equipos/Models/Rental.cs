//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SI656_Alquiler_Equipos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rental
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rental()
        {
            this.RentalDetail = new HashSet<RentalDetail>();
        }
    
        public int Id { get; set; }
        public System.DateTime DateCreated { get; set; }
        public decimal TotalPrice { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int RentalStateId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual RentalState RentalState { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentalDetail> RentalDetail { get; set; }
    }
}
