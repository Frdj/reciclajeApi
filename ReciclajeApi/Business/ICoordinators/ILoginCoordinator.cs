using System.Collections.Generic;
using ReciclajeApi.Business.Models.ApiModels;

namespace ReciclajeApi.Business.ICoordinators
{
    public interface ILoginCoordinator
    {
        int Login(LoginApiModel login);

        int SignUp(SignUpApiModel signUp);
    }
}
