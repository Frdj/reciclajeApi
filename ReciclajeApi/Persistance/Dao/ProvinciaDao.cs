using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class ProvinciaDao : IProvinciaDao
    {
        private readonly IDbConnection _cnn;

        public ProvinciaDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public Provincia ObtenerProvincia(int idProvincia)
        {
            string query = @"SELECT IdProvincia, Descripcion
                            FROM provincias 
                            WHERE IdProvincia = @IdProvincia";

            return _cnn.QueryFirstOrDefault<Provincia>(query, new { IdProvincia = idProvincia });
        }
    }
}