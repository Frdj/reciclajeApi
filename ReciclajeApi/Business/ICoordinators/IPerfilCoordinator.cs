using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface IPerfilCoordinator
    {
        PerfilApiModel ObtenerPerfil(int IdUsuario);
    }
}