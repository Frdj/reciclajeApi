using System.Threading.Tasks;

namespace ReciclajeApi.Business.IServices
{
    public interface IEmailService
    {
        Task<bool> EnviarMail(string asunto, string destinatario, string mensaje);
    }
}