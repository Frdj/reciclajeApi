using Dapper;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReciclajeApi.Persistance.Dao
{
    public class TipDao : ITipDao
    {
        private readonly IDbConnection _cnn;

        public TipDao(IDbConnection cnn)
        {
            this._cnn = cnn;
        }

        public List<Tip> ObtenerTip()
        {
            string query = @"SELECT * FROM tips";

            return _cnn.Query<Tip>(query).ToList();
        }
    }
}