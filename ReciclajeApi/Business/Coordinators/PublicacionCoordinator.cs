using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.IServices;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Business.Models.Exceptions;
using ReciclajeApi.Persistance.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReciclajeApi.Business.Coordinators
{
    public class PublicacionCoordinator : IPublicacionCoordinator
    {
        private readonly IDireccionCoordinator direccionCoordinator;
        private readonly IEstadoCoordinator estadoCoordinator;
        private readonly IPublicacionDao publicacionDao;
        private readonly IResiduoCoordinator residuoCoordinator;
        private readonly IUsuarioCoordinator usuarioCoordinator;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;

        public PublicacionCoordinator(IEstadoCoordinator estadoCoordinator, IDireccionCoordinator direccionCoordinator, IUsuarioCoordinator usuarioCoordinator, IResiduoCoordinator residuoCoordinator, IPublicacionDao publicacionDao, IMapper mapper, IEmailService emailService)
        {
            this.estadoCoordinator = estadoCoordinator;
            this.direccionCoordinator = direccionCoordinator;
            this.usuarioCoordinator = usuarioCoordinator;
            this.residuoCoordinator = residuoCoordinator;
            this.publicacionDao = publicacionDao;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public List<PublicacionApiModel> ObtenerPublicaciones()
        {
            var publicaciones = publicacionDao.ObtenerPublicaciones();

            if (publicaciones == null || !publicaciones.Any())
            {
                throw new PublicacionesNotFoundException();
            }

            return CompletarPublicaciones(publicaciones.ToList());
        }

        public List<PublicacionApiModel> ObtenerPublicacionesPorUsuarioReceptor(int idUsuario)
        {
            if (idUsuario < 1)
            {
                throw new Exception();
            }

            var publicaciones = publicacionDao.ObtenerPublicacionesPorUsuarioReceptor(idUsuario);

            if (publicaciones == null || !publicaciones.Any())
            {
                throw new PublicacionesNotFoundException();
            }

            List<PublicacionApiModel> publis = new List<PublicacionApiModel>();

            foreach (var publicacion in publicaciones)
            {
                publis.Add(CompletarPublicacion(publicacion));
            }

            return publis;
        }

        public List<PublicacionApiModel> ObtenerPublicacionesPorUsuario(int idUsuario)
        {
            if (idUsuario < 1)
            {
                throw new Exception();
            }

            var publicaciones = publicacionDao.ObtenerPublicacionesPorUsuario(idUsuario);

            if (publicaciones == null || !publicaciones.Any())
            {
                throw new PublicacionesNotFoundException();
            }

            List<PublicacionApiModel> publis = new List<PublicacionApiModel>();

            foreach (var publicacion in publicaciones)
            {
                publis.Add(CompletarPublicacion(publicacion));
            }

            return publis;
        }

        public Task<bool> AceptarOferta(int idPublicacion, int idUsuario)
        {
            if (idPublicacion < 1 || idUsuario < 1)
            {
                throw new Exception();
            }

            bool result = false;

            result = publicacionDao.AceptarOferta(idPublicacion, idUsuario);

            if (!result)
            {
                throw new Exception();
            }

            var usuario = usuarioCoordinator.ObtenerUsuario(idUsuario);

            return emailService.EnviarMail("ReciclajeAPP - Te aceptaron tu publicación", usuario.Email, "Estimado/a,<br>Aceptaron tu publicación");
        }

        public Task<bool> ReservarOferta(int idPublicacion, int idUsuario)
        {
            if (idPublicacion < 1 || idUsuario < 1)
            {
                throw new Exception();
            }

            bool result = false;

            result = publicacionDao.ReservarOferta(idPublicacion, idUsuario);

            if (!result)
            {
                throw new Exception();
            }

            var usuario = usuarioCoordinator.ObtenerUsuario(idUsuario);

            return emailService.EnviarMail("ReciclajeAPP - Te reservaron tu publicación", usuario.Email, "Estimado/a,<br>Reservaron tu publicación");
        }

        public bool CrearPublicacion(PublicacionApiModel publicacionApiModel)
        {
            if (publicacionApiModel != null)
            {
                throw new Exception();
            }

            var publicacion = mapper.Map<Publicacion>(publicacionApiModel);

            ValidarPublicacion(publicacion);

            return publicacionDao.CrearPublicacion(publicacion);
        }

        private void ValidarPublicacion(Publicacion publicacion)
        {
            if (publicacion.Cantidad <= 0 || string.IsNullOrWhiteSpace(publicacion.DiasDisponibles)
                || string.IsNullOrWhiteSpace(publicacion.HorarioDisponible) || string.IsNullOrWhiteSpace(publicacion.Medida) || publicacion.NuDireccion <= 0)
            {
                throw new Exception();
            }

            if (residuoCoordinator.ExisteCategoriaResiduo(publicacion.IdCategoriaResiduo))
            {
                throw new Exception();
            }
            if (residuoCoordinator.ExisteTipoResiduo(publicacion.IdTipoResiduo))
            {
                throw new Exception();
            }

            if (usuarioCoordinator.ExisteUsuario(publicacion.IdUsuarioP))
            {
                throw new Exception();
            }
        }

        private List<PublicacionApiModel> CompletarPublicaciones(List<Publicacion> publicaciones)
        {
            List<PublicacionApiModel> publis = new List<PublicacionApiModel>();

            foreach (var publicacion in publicaciones)
            {
                publis.Add(CompletarPublicacion(publicacion));
            }

            return publis;
        }

        private PublicacionApiModel CompletarPublicacion(Publicacion publicacion)
        {
            var publiApiModel = mapper.Map<PublicacionApiModel>(publicacion);

            publiApiModel.CategoriaResiduo = residuoCoordinator.ObtenerCategoriaResiduo(publicacion.IdCategoriaResiduo, publicacion.IdTipoResiduo);
            publiApiModel.TipoResiduo = residuoCoordinator.ObtenerTipoResiduo(publicacion.IdTipoResiduo);
            publiApiModel.UsuarioP = usuarioCoordinator.ObtenerUsuario(publicacion.IdUsuarioP);
            publiApiModel.Direccion = direccionCoordinator.ObtenerDireccion(publicacion.NuDireccion, publicacion.IdUsuarioP);
            publiApiModel.Estado = estadoCoordinator.ObtenerEstado(publicacion.Estado);
            if (publicacion.IdUruarioR.HasValue)
            {
                publiApiModel.UsuarioR = usuarioCoordinator.ObtenerUsuario(publicacion.IdUruarioR.Value);
            }

            return publiApiModel;
        }
    }
}