using System;

namespace ReciclajeApi.Business.Models.Exceptions
{
    public class PublicacionesNotFoundException : Exception
    {
        public PublicacionesNotFoundException() : base("No hay publicaciones") { }
    }
}