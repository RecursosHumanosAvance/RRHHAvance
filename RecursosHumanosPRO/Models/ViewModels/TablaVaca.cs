using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class TablaVaca
    {
        public int IdVacaciones { get; set; }
   
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "desde")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime desde { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "hasta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime hasta { get; set; }

        public int IdContrato { get; set; }
    }
}