using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Persistance.IDao
{
    public interface IDireccionDao
    {
        Direccion ObtenerDireccion(int numeroDireccion, int idUsuario);
    }
}