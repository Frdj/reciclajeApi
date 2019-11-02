using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class UsuarioDao : IUsuarioDao
    {
        private readonly IDbConnection _cnn;

        public UsuarioDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public Usuario ObtenerUsuario(int idUsuario)
        {
            string query = @"SELECT IdUsuario, Email, Nombre, Apellido, FechaNacimiento, FotoDePerfil, Telefono
                            FROM usuarios WHERE IdUsuario = @IdUsuario";

            return _cnn.QueryFirstOrDefault<Usuario>(query, new { IdUsuario = idUsuario });
        }

        public Usuario ObtenerUsuarioPorMail(string email)
        {
            var query = @"SELECT IdUsuario, Email, Nombre, Apellido, FechaNacimiento, FotoDePerfil, Telefono
                        FROM usuarios WHERE Email = @Email";

            return _cnn.QueryFirstOrDefault<Usuario>(query, new { Email = email });
        }

        public bool ValidarUsuario(string email)
        {
            string query = @"SELECT 1 FROM usuarios WHERE Email = @Email";

            return _cnn.QueryFirstOrDefault<bool>(query, new { Email = email });
        }

        public int SignUpUsuario(SignUp signUp)
        {
            string query = @"INSERT INTO usuarios(email, password, nombre, apellido, fechaNacimiento, fotoDePerfil, telefono)
                            VALUES(@Email, @Password, @Nombre, @Apellido, @FechaNacimiento, @FotoDePerfil, @Telefono); select last_insert_id()";

            return _cnn.QueryFirst<int>(query, new { Email = signUp.Email, Password = signUp.Password, Nombre = signUp.Nombre, Apellido = signUp.Apellido, FechaNacimiento = signUp.FechaNacimiento, FotoDePerfil = signUp.FotoDePerfil, Telefono = signUp.Telefono });
        }

        public bool ExisteUsuario(int idUsuario)
        {
            string query = @"SELECT 1 FROM usuarios WHERE IdUsuario = @IdUsuario";

            return _cnn.QueryFirstOrDefault<bool>(query, new { IdUsuario = idUsuario });
        }
    }
}