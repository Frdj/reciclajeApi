using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class EstadoDao : IEstadoDao
    {
        private readonly IDbConnection _cnn;

        public EstadoDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public Estado ObtenerEstado(int idEstado)
        {
            string query = @"SELECT IdEstado, Descripcion
                            FROM estados 
                            WHERE IdEstado = @IdEstado";

            return _cnn.QueryFirstOrDefault<Estado>(query, new { IdEstado = idEstado });
        }
    }
}