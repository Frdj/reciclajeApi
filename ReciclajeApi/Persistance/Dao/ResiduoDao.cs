using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Data;

namespace ReciclajeApi.Persistance.Dao
{
    public class ResiduoDao : IResiduoDao
    {
        private readonly IDbConnection _cnn;

        public ResiduoDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public TipoResiduo ObtenerTipoResiduo(int idTipoResiduo)
        {
            string query = @"SELECT IdTipo, Descripcion 
                            FROM tipo_residuos
                            WHERE idTipo = @IdTipoResiduo";

            return _cnn.QueryFirstOrDefault<TipoResiduo>(query, new { IdTipoResiduo = idTipoResiduo });
        }

        public CategoriaResiduo ObtenerCategoriaResiduo(int idCategoriaResiduo, int idTipoResiduo)
        {
            string query = @"SELECT IdCategoria, IdTipoResiduo, Descripcion, Reciclable, Imagen, Detalle
                            FROM categoria_residuos
                            WHERE IdCategoria = @IdCategoria 
                                AND idTipoResiduo = @IdTipoResiduo";

            return _cnn.QueryFirstOrDefault<CategoriaResiduo>(query, new { IdTipoResiduo = idTipoResiduo, IdCategoria = idCategoriaResiduo });
        }

        public bool ExisteCategoriaResiduo(int idCategoriaResiduo)
        {
            string query = @"SELECT 1 FROM categoria_residuos WHERE IdCategoria = @IdCategoria";

            return _cnn.QueryFirstOrDefault<bool>(query, new { IdCategoria = idCategoriaResiduo });
        }

        public bool ExisteTipoResiduo(int idTipoResiduo)
        {
            string query = @"SELECT 1 FROM tipo_residuos WHERE IdTipo = @IdTipo";

            return _cnn.QueryFirstOrDefault<bool>(query, new { IdTipo = idTipoResiduo });
        }
    }
}