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
            return "Login/GetAll";
        }
        [Route("[controller]/Check")]
        public String Check(LoginSend info)
        {
            return "Login/Check";
        }
    }
}
