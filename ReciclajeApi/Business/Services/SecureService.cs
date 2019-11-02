using ReciclajeApi.Business.IServices;
using ReciclajeApi.Persistance.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciclajeApi.Business.Services
{
    public class SecureService : ISecureService
    {
        private readonly ISecureDao secureDao;
        private readonly string salt = "4sQkUUaNG0nryyT+J8BOHuwWtJAJaRftA9lSKeyOXr4TjpIXXLZQKEmHfCHcM7F8aGHfvJ1I+2UdzVhExhKkcJqraFcZ8PDEX/O3m9Zky2iELjWmU/8Pj/u9MrD1PJg7afipE1uyXK1scIxOzVR3ZcuWONXRBRq0CcdKNt328OU=";

        public SecureService(ISecureDao secureDao)
        {
            this.secureDao = secureDao;
        }

        public bool ValidarPassword(string password, int idUsuario)
        {
            var passHash = CrearPassword(password);

            return secureDao.ValidarPassword(passHash, idUsuario);
        }

        public string CrearPassword(string password)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(salt + password));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
