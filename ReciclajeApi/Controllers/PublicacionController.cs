using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        private readonly IPublicacionCoordinator publicacionCoordinator;

        private readonly IUsuarioCoordinator usuarioCoordinator;

        private readonly IDbConnection _cnn;

        public PublicacionController(IDbConnection cnn, IPublicacionCoordinator publicacionCoordinator, IUsuarioCoordinator usuarioCoordinator)
        {
            _cnn = cnn;
            this.publicacionCoordinator = publicacionCoordinator;
            this.usuarioCoordinator = usuarioCoordinator;
        }

        [HttpGet("publicaciones/creadas")]
        public ActionResult<List<PublicacionApiModel>> GetPublicacionesCreadas([FromQuery] string email)
        {
            try
            {
                var usuario = usuarioCoordinator.ObtenerUsuarioPorMail(email);
                var result = publicacionCoordinator.ObtenerPublicacionesPorUsuario(usuario.IdUsuario);

                return StatusCode(200, result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("publicaciones/aceptadas")] // Obtener las publicaciones aceptadas por el usuario
        public ActionResult<List<PublicacionApiModel>> GetPublicacionesAceptadas(string email)
        {
            try
            {
                var usuario = usuarioCoordinator.ObtenerUsuarioPorMail(email);
                var result = publicacionCoordinator.ObtenerPublicacionesPorUsuarioReceptor(usuario.IdUsuario);

                return StatusCode(200, result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("publicaciones")]
        public ActionResult<List<PublicacionApiModel>> GetPublicaciones()
        {
            try
            {
                var result = publicacionCoordinator.ObtenerPublicaciones();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("publicaciones/reservar")]
        public ActionResult<bool> ReservarOferta(int idPublicacion, int idUsuario)
        {
            try
            {
                var result = publicacionCoordinator.ReservarOferta(idPublicacion, idUsuario);
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("publicaciones")]
        public ActionResult<bool> CrearPublicacion(PublicacionApiModel publicacionApiModel)
        {
            try
            {
                var result = publicacionCoordinator.CrearPublicacion(publicacionApiModel);
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("publicaciones/retirar")]
        public ActionResult<bool> AceptarOferta(int idPublicacion, int idUsuario)
        {
            try
            {
                var result = publicacionCoordinator.AceptarOferta(idPublicacion, idUsuario);
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}