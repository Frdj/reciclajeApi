using System.Collections.Generic;
using ReciclajeApi.Business.Models.Domain;

namespace ReciclajeApi.Persistance.IDao
{
    public interface ITipDao{
        List<Tip> ObtenerTip ();
    }
}