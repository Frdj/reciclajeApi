using ReciclajeApi.Business.Models.Domain;
namespace ReciclajeApi.Persistance.IDao
{
    public interface IResiduoDao
    {
        TipoResiduo ObtenerTipoResiduo(int idTipoResiduo);

        CategoriaResiduo ObtenerCategoriaResiduo(int idCategoriaResiduo, int idTipoResiduo);

        bool ExisteCategoriaResiduo(int idCategoriaResiduo);

        bool ExisteTipoResiduo(int idTipoResiduo);
    }
}