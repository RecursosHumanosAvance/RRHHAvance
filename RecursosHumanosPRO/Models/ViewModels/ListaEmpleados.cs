using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class ListaEmpleados { 
    public int IdEmpleado { get; set; }
    public string Nombre{ get; set; }
        public string Apellido{ get; set; }
        public string Direccion { get; set; }
        public string Sexo{ get; set; }
        public string Telefono{ get; set; }
        public string Nit{ get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public int IdPuesto{ get; set; }
        public string NombrePuesto { get; set; }


}
}