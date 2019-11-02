namespace ReciclajeApi.Business.IServices
{
    public interface ISecureService
    {
        bool ValidarPassword(string password, int idUsuario);

        string CrearPassword(string password);
    }
}
