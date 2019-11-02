using System;
using Microsoft.AspNetCore.Mvc;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilCoordinator perfilCoordinator;

        public PerfilController(IPerfilCoordinator perfilCoordinator)
        {
            this.perfilCoordinator = perfilCoordinator;
        }

        [HttpGet("perfil/{IdUsuario}")]
        public ActionResult<PerfilApiModel> ObtenerPerfil(int IdUsuario)
        {
            try
            {
                var result = perfilCoordinator.ObtenerPerfil(IdUsuario);

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(403);
            }
        }

    }
}
