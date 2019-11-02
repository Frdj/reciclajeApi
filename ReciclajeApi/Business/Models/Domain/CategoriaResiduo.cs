namespace ReciclajeApi.Business.Models.Domain
{
    public class CategoriaResiduo
    {
        public int IdCategoria { get; set; }

        public int IdTipoResiduo { get; set; }

        public string Descripcion { get; set; }

        public bool Reciclable { get; set; }

        public byte[] Imagen { get; set; }

        public string Detalle { get; set; }
    }
}