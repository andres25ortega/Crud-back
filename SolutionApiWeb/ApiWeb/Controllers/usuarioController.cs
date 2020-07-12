using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Modelo;

namespace ApiWeb.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class usuarioController : ApiController
    {
        [HttpPost]
        [Route("ObtenerUsuarios")]
        public IHttpActionResult Get()
        {
            string error = string.Empty;
            try
            {
                usuario_bll usuario_bll = new usuario_bll();
                var usuarios = usuario_bll.ObtenerUsuarios(ref error);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return Ok(usuarios);

            }
            catch (Exception e)
            {
                error = e.Message;
                return BadRequest(error);
            }

        }

        [HttpPost]
        [Route("CrearUsuarios")]
        public IHttpActionResult Post(usuarios_modelo usuario)
        {
            string error = string.Empty;
            try
            {
                usuario_bll usuario_bll = new usuario_bll();
                var usuarioCrear = usuario_bll.CrearUsuario(ref error, usuario);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return Ok(usuarioCrear);

            }
            catch (Exception e)
            {
                error = e.Message;
                return BadRequest(error);
            }

        }

        [HttpPost]
        [Route("ActualizarUsuario")]
        public IHttpActionResult Put(usuarios_modelo usuario)
        {
            string error = string.Empty;
            try
            {
                usuario_bll usuario_bll = new usuario_bll();
                var usuarioActualiza = usuario_bll.ActualizarUsuario(ref error, usuario);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return Ok(usuarioActualiza);

            }
            catch (Exception e)
            {
                error = e.Message;
                return BadRequest(error);
            }

        }

        [HttpPost]
        [Route("EliminarUsuario")]
        public IHttpActionResult Delete(usuarios_modelo usuario)
        {
            string error = string.Empty;
            try
            {
                usuario_bll usuario_bll = new usuario_bll();
                var usuarioEliminar = usuario_bll.EliminarUsuario(ref error, usuario);
                if (!string.IsNullOrEmpty(error)) throw new Exception(error);

                return Ok(usuarioEliminar);

            }
            catch (Exception e)
            {
                error = e.Message;
                return BadRequest(error);
            }

        }
    }
}
