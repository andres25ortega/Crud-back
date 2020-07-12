using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Modelo;

namespace BLL
{
    public class usuario_bll
    {
        public List<object> ObtenerUsuarios(ref string error)
        {
            error = string.Empty;
            try
            {
                usuarios_dto usuarios_dto = new usuarios_dto();
                var listaUsuarios = usuarios_dto.GetUsuarios(ref error);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                List<Modelo.usuarios_modelo> lista = new List<Modelo.usuarios_modelo>();
                Modelo.usuarios_modelo Model = null;

                foreach (var usuario in listaUsuarios)
                {
                    Model = (Modelo.usuarios_modelo)usuario;
                    lista.Add(Model);
                }

                List<object> retorno = new List<object>();
                retorno.Add(lista);

                return retorno;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }

        }

        public bool CrearUsuario(ref string error, Modelo.usuarios_modelo usuario)
        {
            error = string.Empty;
            try
            {
                DTO.Usuarios_Tabla model;
                model = (DTO.Usuarios_Tabla)usuario;

                usuarios_dto usuarios_dto = new usuarios_dto();
                var usuarioValidar = usuarios_dto.ValidarUsuario(ref error, model.cedula);
                if (usuarioValidar != null) throw new Exception("Cedula ya existente");            

                var insertarUsuario = usuarios_dto.Insertar(ref error, model);
                if (!insertarUsuario) throw new Exception(error);

                return true;

            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public bool ActualizarUsuario(ref string error, Modelo.usuarios_modelo usuario)
        {
            error = string.Empty;
            try
            {
                DTO.Usuarios_Tabla model;
                model = (DTO.Usuarios_Tabla)usuario;

                usuarios_dto usuarios_dto = new usuarios_dto();
                var usuarioValidar = usuarios_dto.ValidarUsuario(ref error, model.cedula);
                if (usuarioValidar == null) throw new Exception("Usuario no existe");

                model.apellidos = usuario.apellidos;
                model.celular = usuario.celular;
                model.correo = usuario.correo;
                model.nombres = usuario.nombres;
                model.perfil = usuario.perfil;
                model.cedula = usuario.cedula;                

                var ActualizarUsuario = usuarios_dto.Actualizar(ref error, model);
                if (!ActualizarUsuario) throw new Exception(error);

                return true;

            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

        public bool EliminarUsuario(ref string error, Modelo.usuarios_modelo usuario)
        {
            error = string.Empty;
            try
            {
                DTO.Usuarios_Tabla model;
                model = (DTO.Usuarios_Tabla)usuario;

                usuarios_dto usuarios_dto = new usuarios_dto();
                var usuarioValidar = usuarios_dto.ValidarUsuario(ref error, model.cedula);
                if (usuarioValidar == null) throw new Exception("Cedula no existente");

                var insertarUsuario = usuarios_dto.Delete(ref error, model);
                if (!insertarUsuario) throw new Exception(error);

                return true;

            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }

    }
}
