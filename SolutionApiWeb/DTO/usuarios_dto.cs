using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class usuarios_dto: DAOBase<Usuarios_Tabla>
    {
        public List<Usuarios_Tabla> GetUsuarios(ref string error)
        {
			try
			{
				using (workspaceEntities bd = new workspaceEntities()) // workspaceEntities -> nombre de conexíón a bd
				{
					var query = (from item in bd.Usuarios_Tabla
								 select item).ToList();
					return query;
				}
			}
			catch (Exception e)
			{
				error = e.Message;
				return null;
			}
        }

		public Usuarios_Tabla ValidarUsuario(ref string error, string cedula)
		{
			try
			{
				Usuarios_Tabla resultado = null;

				using (workspaceEntities bd = new workspaceEntities()) // workspaceEntities -> nombre de conexíón a bd
				{
					var query = (from item in bd.Usuarios_Tabla
								 where item.cedula == cedula
								 select item);

					resultado = query.FirstOrDefault<Usuarios_Tabla>();
				}

				return resultado;
			}
			catch (Exception e)
			{
				error = e.Message;
				return null;
			}
		}

	}
}
