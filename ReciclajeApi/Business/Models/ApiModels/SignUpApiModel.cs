using System;

namespace ReciclajeApi.Business.Models.ApiModels
{
    public class SignUpApiModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string FotoDePerfil { get; set; }

        public int Telefono { get; set; }
    }
}