using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Persistance.IDao
{
    public interface IEstadoDao
    {
        Estado ObtenerEstado(int idEstado);
    }
}