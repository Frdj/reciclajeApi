using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Persistance.IDao;
using System;

namespace ReciclajeApi.Business.Coordinators
{
    public class ResiduoCoordinator : IResiduoCoordinator
    {
        private readonly IResiduoDao residuoDao;
        private readonly IMapper mapper;

        public ResiduoCoordinator(IResiduoDao residuoDao, IMapper mapper)
        {
            this.residuoDao = residuoDao;
            this.mapper = mapper;
        }

        public TipoResiduoApiModel ObtenerTipoResiduo(int idTipoResiduo)
        {
            if (idTipoResiduo < 1)
            {
                throw new Exception();
            }

            var tipoResiduo = residuoDao.ObtenerTipoResiduo(idTipoResiduo);

            if (tipoResiduo == null)
            {
                throw new Exception();
            }

            return mapper.Map<TipoResiduoApiModel>(tipoResiduo);
        }

        public CategoriaResiduoApiModel ObtenerCategoriaResiduo(int idCategoriaResiduo, int idTipoResiduo)
        {
            if (idCategoriaResiduo < 1)
            {
                throw new Exception();
            }

            var categoriaResiduo = residuoDao.ObtenerCategoriaResiduo(idCategoriaResiduo, idTipoResiduo);

            if (categoriaResiduo == null)
            {
                throw new Exception();
            }

            var cat = mapper.Map<CategoriaResiduoApiModel>(categoriaResiduo);
            cat.TipoResiduo = ObtenerTipoResiduo(idTipoResiduo);

            return cat;
        }

        public bool ExisteCategoriaResiduo(int idCategoriaResiduo)
        {
            if (idCategoriaResiduo < 1)
            {
                throw new Exception();
            }

            return residuoDao.ExisteCategoriaResiduo(idCategoriaResiduo);
        }

        public bool ExisteTipoResiduo(int idTipoResiduo)
        {
            if (idTipoResiduo < 1)
            {
                throw new Exception();
            }

            return residuoDao.ExisteTipoResiduo(idTipoResiduo);
        }
    }
}