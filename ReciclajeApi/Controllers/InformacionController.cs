using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class InformacionController : ControllerBase
    {
        private readonly IInformacionCoordinator informacionCoordinator;

        public InformacionController(IInformacionCoordinator informacionCoordinator)
        {
            this.informacionCoordinator = informacionCoordinator;
        }

        [HttpGet("materiales")]
        public ActionResult<List<MaterialApiModel>> ObtenerMateriales()
        {
            try
            {
                var result = informacionCoordinator.ObtenerMateriales();

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(403);
            }
        }

        [HttpGet("tip")]
        public ActionResult<List<MaterialApiModel>> ObtenerTip()
        {
            try
            {
                var result = informacionCoordinator.ObtenerTip();

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(403);
            }
        }
    }
}
