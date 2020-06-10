using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecursosHumanosPRO.Models.ViewModels
{
    public class ListaUsuarios
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
    }
}