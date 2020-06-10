using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class ListaContrato
    {
        public int IdContrato { get; set; }
        public string Nombre{ get; set; }
        public Decimal Salario { get; set; }
        public string JornadaLAboral { get; set; }
        public string DiasdeDescanso { get; set; }
        public DateTime Fecha_de_contrato { get; set; }

    }
}