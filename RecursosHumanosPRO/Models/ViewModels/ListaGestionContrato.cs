using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class ListaGestionContrato
    {
        public Contratos Contrato { get; set; }
        public Empleados Empleado { get; set; }
        public List<Vacaciones> Vacaciones { get; set; }
    }
}