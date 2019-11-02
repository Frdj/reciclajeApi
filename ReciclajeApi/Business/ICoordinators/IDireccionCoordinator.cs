using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface IDireccionCoordinator
    {
        DireccionApiModel ObtenerDireccion(int numeroDireccion, int idUsuario);
    }
}