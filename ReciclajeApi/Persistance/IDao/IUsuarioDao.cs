using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Persistance.IDao
{
    public interface IUsuarioDao
    {
        Usuario ObtenerUsuario(int idUsuario);

        Usuario ObtenerUsuarioPorMail(string email);

        bool ValidarUsuario(string email);

        int SignUpUsuario(SignUp signUp);

        bool ExisteUsuario(int idUsuario);
    }
}