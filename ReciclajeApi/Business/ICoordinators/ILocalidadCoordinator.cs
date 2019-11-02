using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface ILocalidadCoordinator
    {
        LocalidadApiModel ObtenerLocalidad(int idLocalidad, int idProvincia);
    }
}