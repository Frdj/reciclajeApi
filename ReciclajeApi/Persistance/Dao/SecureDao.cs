using Dapper;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class SecureDao : ISecureDao
    {
        private readonly IDbConnection _cnn;

        public SecureDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public bool ValidarPassword(string passHash, int idUsuario)
        {
            string query = @"SELECT 1
                            FROM usuarios WHERE IdUsuario = @IdUsuario AND password = @Password";

            return _cnn.QueryFirstOrDefault<bool>(query, new { IdUsuario = idUsuario, Password = passHash });
        }
    }
}