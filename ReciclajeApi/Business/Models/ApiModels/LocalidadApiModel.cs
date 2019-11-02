namespace ReciclajeApi.Business.Models.ApiModels
{
    public class LocalidadApiModel
    {
        public int IdLocalidad { get; set; }

        public ProvinciaApiModel Provincia { get; set; }

        public string Descripcion { get; set; }
    }
}