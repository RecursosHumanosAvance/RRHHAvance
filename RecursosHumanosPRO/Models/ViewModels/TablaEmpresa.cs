using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaEmpresa
    {
        public int IdEmpresa { get; set; }
        [Required]
        [StringLength(50)]
        [Display (Name="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
    }
}