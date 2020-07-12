using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class usuarios_modelo
    {
        public string cedula { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string perfil { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public Nullable<System.DateTime> creacion { get; set; }

        public static explicit operator usuarios_modelo(DTO.Usuarios_Tabla v)
        {
            usuarios_modelo temp = new usuarios_modelo();

            temp.nombres = v.nombres;
            temp.apellidos = v.apellidos;
            temp.cedula = v.cedula;
            temp.celular = v.celular;
            temp.correo = v.correo;
            temp.creacion = v.creacion;
            temp.perfil = v.perfil;

            return temp;
        }

        public static explicit operator DTO.Usuarios_Tabla(usuarios_modelo v)
        {
            DTO.Usuarios_Tabla temp = new DTO.Usuarios_Tabla();

            temp.nombres = v.nombres;
            temp.apellidos = v.apellidos;
            temp.cedula = v.cedula;
            temp.celular = v.celular;
            temp.correo = v.correo;
            temp.creacion = v.creacion;
            temp.perfil = v.perfil;

            return temp;
        }
    }
}
