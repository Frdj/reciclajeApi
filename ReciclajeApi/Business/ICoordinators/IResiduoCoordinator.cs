using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface IResiduoCoordinator
    {
        TipoResiduoApiModel ObtenerTipoResiduo(int idTipoResiduo);

        CategoriaResiduoApiModel ObtenerCategoriaResiduo(int idCategoriaResiduo, int idTipoResiduo);

        bool ExisteCategoriaResiduo(int idCategoriaResiduo);

        bool ExisteTipoResiduo(int idTipoResiduo);
    }
}