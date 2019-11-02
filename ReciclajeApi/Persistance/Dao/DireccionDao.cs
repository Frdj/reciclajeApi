using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class DireccionDao : IDireccionDao
    {
        private readonly IDbConnection _cnn;

        public DireccionDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public Direccion ObtenerDireccion(int numeroDireccion, int idUsuario)
        {
            string query = @"SELECT IdUsuario, NuDireccion, IdProvincia, IdLocalidad, Domicilio, Barrio 
                            FROM direcciones 
                            WHERE NuDireccion = @NuDireccion AND IdUsuario = @IdUsuario";

            return _cnn.QueryFirstOrDefault<Direccion>(query, new { NuDireccion = numeroDireccion, IdUsuario = idUsuario });
        }
    }
}