using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaUsuarios
    {
        [Required]
        [Display(Name = "Idusuario")]
        public int Idusuario { get; set; }
        [Required]
        [StringLength(90)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }//

        [Required]
        [StringLength(70)]
        [Display(Name = "Apellido")]
        public string Apellidos { get; set; }

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
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Pass")]
        public string Pass { get; set; }
    }
}