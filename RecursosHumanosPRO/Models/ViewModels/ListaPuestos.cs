using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class ListaPuestos
    {
        public int IdPuesto { get; set; }
        public string NombrePuesto{ get; set; }
        public int IdDepartamentos { get; set; }
        public string Descripcion { get; set; }
        public string NombreDepartamento { get; set; }

    }
}