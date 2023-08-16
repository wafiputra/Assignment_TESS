using assignment_tess.Models;
using assignment_tess.Models.Helper;
using assignment_tess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_tess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Auth user = new Auth();

        [HttpPost]
        [Route("[action]")]
        public ResponseHandler Register([FromBody] RegisterModel registerModel)
        {
            ResponseHandler response = new AuthService().RegisterService(registerModel);
            return response;
        }

        [HttpPost]
        [Route("[action]")]
        public ResponseHandler Login([FromBody] LoginModel loginModel)
        {
            ResponseHandler response = new AuthService().LoginService(loginModel);
            return response;
        }
    }
}
