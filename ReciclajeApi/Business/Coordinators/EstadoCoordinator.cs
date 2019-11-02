using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Persistance.IDao;
using System;

namespace ReciclajeApi.Business.Coordinators
{
    public class EstadoCoordinator : IEstadoCoordinator
    {
        private readonly IEstadoDao estadoDao;
        private readonly IMapper mapper;

        public EstadoCoordinator(IEstadoDao estadoDao, IMapper mapper)
        {
            this.estadoDao = estadoDao;
            this.mapper = mapper;
        }

        public EstadoApiModel ObtenerEstado(int idEstado)
        {
            if (idEstado < 1)
            {
                throw new Exception();
            }

            var result = estadoDao.ObtenerEstado(idEstado);

            if (result == null)
            {
                throw new Exception();
            }

            return mapper.Map<EstadoApiModel>(result);
        }
    }
}