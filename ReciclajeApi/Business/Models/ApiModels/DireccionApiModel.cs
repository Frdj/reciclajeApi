namespace ReciclajeApi.Business.Models.ApiModels
{
    public class DireccionApiModel
    {
        public int NuDireccion { get; set; }

        public UsuarioApiModel Usuario { get; set; }

        public ProvinciaApiModel Provincia { get; set; }

        public LocalidadApiModel Localidad { get; set; }

        public string Domicilio { get; set; }

        public string Barrio { get; set; }
    }
}