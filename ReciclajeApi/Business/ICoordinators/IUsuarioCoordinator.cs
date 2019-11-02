using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface IUsuarioCoordinator
    {
        UsuarioApiModel ObtenerUsuario(int idUsuario);

        UsuarioApiModel ObtenerUsuarioPorMail(string email);

        bool ValidarUsuario(string email);

        int SignUpUsuario(SignUp signUp);

        bool ExisteUsuario(int idUsuario);
    }
}