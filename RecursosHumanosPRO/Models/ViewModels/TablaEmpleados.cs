using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaEmpleados
    {
        [Required]
        [Display(Name = "IdEmpleado")]
        public int IdEmpleado { get; set; }
        [Required]
        [StringLength(90)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }//

        [Required]
        [StringLength(70)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nit")]
        public string Nit { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Required]
        [Display(Name = "Puesto")]
        public int IdPuesto { get; set; }
    }
}