using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaContrato
    {
        public int IdContrato { get; set; }
        public int IdEmpleado { get; set; }

        [Required]
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }

        [Required]
        [StringLength(90)]
        [Display(Name = "JornadaLAboral")]
        public string JornadaLAboral { get; set; }

        [Required]
        [StringLength(90)]
        [Display(Name = "DiasdeDescanso")]
        public string  DiasdeDescanso { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha_de_contrato")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime Fecha_de_contrato { get; set; }
       
    }
}