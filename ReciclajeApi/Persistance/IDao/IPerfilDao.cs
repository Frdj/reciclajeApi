using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Persistance.IDao{
    public interface IPerfilDao{
        Perfil ObtenerPerfil(int IdUsuario);
    }
}