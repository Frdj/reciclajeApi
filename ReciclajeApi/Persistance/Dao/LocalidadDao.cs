using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class LocalidadDao : ILocalidadDao
    {
        private readonly IDbConnection _cnn;

        public LocalidadDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public Localidad ObtenerLocalidad(int idLocalidad, int idProvincia)
        {
            string query = @"SELECT IdProvincia, IdLocalidad, Descripcion
                            FROM localidades 
                            WHERE IdLocalidad = @IdLocalidad AND IdProvincia = @IdProvincia";

            return _cnn.QueryFirstOrDefault<Localidad>(query, new { IdLocalidad = idLocalidad, IdProvincia = idProvincia });
        }
    }
}