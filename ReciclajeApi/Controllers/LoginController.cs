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
    public class LoginController : ControllerBase
    {
        private readonly ILoginCoordinator loginCoordinator;

        private readonly IDbConnection _cnn;
        public LoginController(IDbConnection cnn, ILoginCoordinator loginCoordinator)
        {
            _cnn = cnn;
            this.loginCoordinator = loginCoordinator;
        }

        [HttpPost("login")]
        public ActionResult<int> Login([FromBody] LoginApiModel login)
        {
            try
            {
                var result = loginCoordinator.Login(login);

                return StatusCode(200, result);
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }

        [HttpPost("signup")]
        public ActionResult<int> SignUp([FromBody] SignUpApiModel signUp)
        {
            try
            {
                var result = loginCoordinator.SignUp(signUp);

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(403);
            }
        }
    }
}