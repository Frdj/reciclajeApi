using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReciclajeApi.Persistance.Dao
{
    public class InformacionDao : IInformacionDao
    {
        private readonly IDbConnection _cnn;

        public InformacionDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public List<Material> ObtenerMateriales()
        {
            string query = @"SELECT ts.descripcion as NombreMaterial, cr.descripcion as Residuo, cr.reciclable as EsReciclable, cr.imagen as Imagen, cr.Detalle 
                            FROM categoria_residuos cr 
                            INNER JOIN tipo_residuos ts ON ts.idTipo = cr.idTipoResiduo";

            return _cnn.Query<Material>(query).ToList();
        }
    }
}