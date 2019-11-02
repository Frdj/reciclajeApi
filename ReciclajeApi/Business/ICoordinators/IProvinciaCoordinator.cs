using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface IProvinciaCoordinator
    {
        ProvinciaApiModel ObtenerProvincia(int idProvincia);
    }
}