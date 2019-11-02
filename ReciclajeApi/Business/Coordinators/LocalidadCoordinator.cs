using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Persistance.IDao;
using System;

namespace ReciclajeApi.Business.Coordinators
{
    public class LocalidadCoordinator : ILocalidadCoordinator
    {
        private readonly ILocalidadDao localidadDao;
        private readonly IProvinciaCoordinator provinciaCoordinator;
        private readonly IMapper mapper;

        public LocalidadCoordinator(IProvinciaCoordinator provinciaCoordinator, ILocalidadDao localidadDao, IMapper mapper)
        {
            this.provinciaCoordinator = provinciaCoordinator;
            this.localidadDao = localidadDao;
            this.mapper = mapper;
        }

        public LocalidadApiModel ObtenerLocalidad(int idLocalidad, int idProvincia)
        {
            if (idLocalidad < 1 || idProvincia < 1)
            {
                throw new Exception();
            }

            var result = localidadDao.ObtenerLocalidad(idLocalidad, idProvincia);

            if (result == null)
            {
                throw new Exception();
            }

            var localidad = mapper.Map<LocalidadApiModel>(result);
            localidad.Provincia = provinciaCoordinator.ObtenerProvincia(result.IdProvincia);

            return localidad;
        }
    }
}