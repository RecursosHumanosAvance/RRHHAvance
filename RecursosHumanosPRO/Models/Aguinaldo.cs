//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecursosHumanosPRO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aguinaldo
    {
        public int IdAguinaldo { get; set; }
        public Nullable<System.DateTime> FechaActual { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> IdContrato { get; set; }
    
        public virtual Contratos Contratos { get; set; }
    }
}
