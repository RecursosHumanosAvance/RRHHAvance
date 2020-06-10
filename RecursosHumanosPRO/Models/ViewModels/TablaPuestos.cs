using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaPuestos
    {
        public int IdPuesto{ get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string NombrePuesto { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        public int IdDepartamentos { get; set; }
    }
}