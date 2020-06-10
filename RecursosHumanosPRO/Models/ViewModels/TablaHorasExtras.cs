using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaHorasExtras
    {
        public int IdHorasExtras{ get; set; }

        [Required]
        [Display(Name = "IdEmpleado")]
        public int IdEmpleado { get; set; }

        [Required]
        [Display(Name = "TablaHora")]
        public int TablaHora { get; set; }

        [Required]
        [Display(Name = "PrecioHora")]
        public decimal PrecioHora { get; set; }

       


     
    }
}