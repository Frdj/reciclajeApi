using System;

namespace ReciclajeApi.Business.Models.ApiModels
{
    public class PublicacionApiModel
    {
        public int IdPublicacion { get; set; }

        public UsuarioApiModel UsuarioP { get; set; }

        public DireccionApiModel Direccion { get; set; }

        public TipoResiduoApiModel TipoResiduo { get; set; }

        public CategoriaResiduoApiModel CategoriaResiduo { get; set; }

        public int Cantidad { get; set; }

        public string Medida { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public EstadoApiModel Estado { get; set; }

        public string DiasDisponibles { get; set; }

        public string HorarioDisponible { get; set; }

        public UsuarioApiModel UsuarioR { get; set; }

        public DateTime? FechaRetiro { get; set; }
    }
}