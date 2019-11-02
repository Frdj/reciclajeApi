using ReciclajeApi.Business.Models.Domain;
using System.Collections.Generic;

namespace ReciclajeApi.Persistance.IDao
{
    public interface IInformacionDao
    {
        List<Material> ObtenerMateriales();
    }
}