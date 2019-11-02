using ReciclajeApi.Business.Models.ApiModels;
using System.Collections.Generic;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface IInformacionCoordinator
    {
        List<MaterialApiModel> ObtenerMateriales();
        string ObtenerTip();
    }
}