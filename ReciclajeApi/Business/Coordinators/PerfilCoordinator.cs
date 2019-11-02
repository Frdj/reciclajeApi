using System;
using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;

namespace ReciclajeApi.Business.Coordinators
{
    public class PerfilCoordinator : IPerfilCoordinator
    {
        private readonly IPerfilDao perfilDao;
        private readonly IMapper mapper;

        public PerfilCoordinator(IPerfilDao perfilDao, IMapper mapper)
        {
            this.perfilDao = perfilDao;
            this.mapper = mapper;
        }

        public PerfilApiModel ObtenerPerfil(int IdUsuario)
        {
            var result = perfilDao.ObtenerPerfil(IdUsuario);

            if (result == null)
            {
                throw new Exception();
            }

            return mapper.Map<PerfilApiModel>(result);
        }

    }
}