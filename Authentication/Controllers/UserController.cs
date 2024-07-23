using Authentication.Services.User.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IUserService _userService;

        public UserController(IDataProtectionProvider dataProtectionProvider, IUserService userService)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var protector = _dataProtectionProvider.CreateProtector("auth-cookie");
            HttpContext.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:pedro")}";

            return Ok("Login feito com sucesso!!");
        }

        [HttpGet("info/username")]
        public IActionResult GetUsername()
        {
            var protector = _dataProtectionProvider.CreateProtector("auth-cookie");

            var authCookie = HttpContext.Request.Headers["Cookie"].FirstOrDefault(c => c.StartsWith("auth="));
            if (authCookie == null)
            {
                return BadRequest("Auth cookie não foi encontrado.");
            }
            var resultUsername = _userService.GetUsername(authCookie, protector);
            return Ok(resultUsername);

        }
    }
}
