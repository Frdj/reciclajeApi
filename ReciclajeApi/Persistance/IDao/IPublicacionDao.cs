using ReciclajeApi.Business.Models.Domain;
using System.Collections.Generic;

namespace ReciclajeApi.Persistance.IDao
{
    public interface IPublicacionDao
    {
        IEnumerable<Publicacion> ObtenerPublicaciones();

        IEnumerable<Publicacion> ObtenerPublicacionesPorUsuario(int idUsuario);

        IEnumerable<Publicacion> ObtenerPublicacionesPorUsuarioReceptor(int idUsuario);

        bool AceptarOferta(int idPublicacion, int idUsuario);

        bool ReservarOferta(int idPublicacion, int idUsuario);

        bool CrearPublicacion(Publicacion publicacion);
    }
}