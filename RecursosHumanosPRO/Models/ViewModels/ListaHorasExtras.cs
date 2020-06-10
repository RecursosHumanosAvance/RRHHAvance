using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class ListaHorasExtras
    {
        public int IdHorasExtras { get; set; }
        public int IdEmpleado { get; set; }
        public int TablaHora { get; set; }
        public Decimal PrecioHora { get; set; }
    }
}