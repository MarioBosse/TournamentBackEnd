using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {
        // Donne la liste de tous les courriels enregistrés
        [Route("[controller]/All")]
        public String GetAll()
        {
            return "Login/GetAll\nVa donner la liste de tout le usager existant";
        }
        [Route("[controller]/Check")]
        public String Check(LoginSend info)
        {
            return info.Courriel + '\n' + "Login/Check\nSi le client existe, retourne un TOKEN, sinon," + '\n' + "retourne FALSE pour effectuer la création d'un nouveu profil";
        }
    }
}
