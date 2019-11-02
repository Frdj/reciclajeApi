using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface IEstadoCoordinator
    {
        EstadoApiModel ObtenerEstado(int idEstado);
    }
}