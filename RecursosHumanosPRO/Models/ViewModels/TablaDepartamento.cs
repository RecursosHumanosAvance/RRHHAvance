using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaDepartamento
    {
        public int IdDepartamento{ get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string NombreDepa { get; set; }
        [Required]
        [Display(Name = "Empresa")]
        public int Idempresa{ get; set; }
    }
}