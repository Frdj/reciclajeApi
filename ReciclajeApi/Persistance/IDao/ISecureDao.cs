using System;
namespace ReciclajeApi.Persistance.IDao
{
    public interface ISecureDao
    {
        bool ValidarPassword(string passHash, int idUsuario);
    }
}