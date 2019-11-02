using System;

namespace ReciclajeApi.Business.Models.Domain
{
    public class Publicacion
    {
        public int IdPublicacion { get; set; }

        public int IdUsuarioP { get; set; }

        public int NuDireccion { get; set; }

        public int IdTipoResiduo { get; set; }

        public int IdCategoriaResiduo { get; set; }

        public int Cantidad { get; set; }

        public string Medida { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public int Estado { get; set; }

        public string DiasDisponibles { get; set; }

        public string HorarioDisponible { get; set; }

        public int? IdUruarioR { get; set; }

        public DateTime? FechaRetiro { get; set; }
    }
}