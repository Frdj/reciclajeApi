using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.IServices;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Business.Models.Domain;
using System;

namespace ReciclajeApi.Business.Coordinators
{
    public class LoginCoordinator : ILoginCoordinator
    {
        private readonly IMapper mapper;

        private readonly IUsuarioCoordinator usuarioCoordinator;

        private readonly ISecureService secureService;

        public LoginCoordinator(IMapper mapper, IUsuarioCoordinator usuarioCoordinator, ISecureService secureService)
        {
            this.mapper = mapper;
            this.usuarioCoordinator = usuarioCoordinator;
            this.secureService = secureService;
        }

        public int Login(LoginApiModel login)
        {
            if (login == null)
            {
                throw new Exception();
            }

            bool usuarioValidado = usuarioCoordinator.ValidarUsuario(login.Email);

            if (!usuarioValidado)
            {
                throw new Exception();
            }

            UsuarioApiModel usuario = usuarioCoordinator.ObtenerUsuarioPorMail(login.Email);

            bool passwordValida = secureService.ValidarPassword(login.Password, usuario.IdUsuario);

            if (!passwordValida)
            {
                throw new Exception();
            }

            if (usuarioValidado && passwordValida)
            {
                return usuario.IdUsuario;
            }

            throw new Exception();
        }

        public int SignUp(SignUpApiModel signUp)
        {
            ValidarSignUp(signUp);

            var pass = secureService.CrearPassword(signUp.Password);

            SignUp request = mapper.Map<SignUp>(signUp);
            request.Password = pass;

            request.FotoDePerfil = Convert.FromBase64String(signUp.FotoDePerfil);

            return usuarioCoordinator.SignUpUsuario(request);
        }

        private void ValidarSignUp(SignUpApiModel signUp)
        {
            if (signUp == null)
            {
                throw new Exception();
            }

            var existeUsuario = usuarioCoordinator.ValidarUsuario(signUp.Email);

            if (existeUsuario)
            {
                throw new Exception();
            }
            //TODO agregar más validaciones a los datos. Cualquier error lanza excepcion.
        }
    }
}