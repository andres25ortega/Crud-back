//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Perfiles_Tabla
    {
        public Perfiles_Tabla()
        {
            this.Usuarios_Tabla = new HashSet<Usuarios_Tabla>();
        }
    
        public int id { get; set; }
        public string perfil { get; set; }
    
        public virtual ICollection<Usuarios_Tabla> Usuarios_Tabla { get; set; }
    }
}
