using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class PerfilDao : IPerfilDao
    {
        private readonly IDbConnection _cnn;

        public PerfilDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public Perfil ObtenerPerfil(int IdUsuario)
        {
            var query = "SELECT IdUsuario, Email, Nombre, Apellido, FotoDePerfil, Telefono FROM usuarios WHERE IdUsuario = @IdUsuario";

            return _cnn.QueryFirstOrDefault<Perfil>(query, new { IdUsuario = @IdUsuario });

        }
    }
}