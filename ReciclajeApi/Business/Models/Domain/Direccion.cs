namespace ReciclajeApi.Business.Models.Domain
{
    public class Direccion
    {
        public int NuDireccion { get; set; }

        public int IdUsuario { get; set; }

        public int IdProvincia { get; set; }

        public int IdLocalidad { get; set; }

        public string Domicilio { get; set; }

        public string Barrio { get; set; }
    }
}