using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Persistance.IDao
{
    public interface ILocalidadDao
    {
        Localidad ObtenerLocalidad(int idLocalidad, int idProvincia);
    }
}