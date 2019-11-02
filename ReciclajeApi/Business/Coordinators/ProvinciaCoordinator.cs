using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Persistance.IDao;
using System;

namespace ReciclajeApi.Business.Coordinators
{
    public class ProvinciaCoordinator : IProvinciaCoordinator
    {
        private readonly IProvinciaDao provinciaDao;
        private readonly IMapper mapper;

        public ProvinciaCoordinator(IProvinciaDao provinciaDao, IMapper mapper)
        {
            this.provinciaDao = provinciaDao;
            this.mapper = mapper;
        }

        public ProvinciaApiModel ObtenerProvincia(int idProvincia)
        {
            if (idProvincia < 1)
            {
                throw new Exception();
            }

            var result = provinciaDao.ObtenerProvincia(idProvincia);

            if (result == null)
            {
                throw new Exception();
            }

            return mapper.Map<ProvinciaApiModel>(result);
        }
    }
}