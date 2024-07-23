using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly HttpContent _httpContent;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public UserController(HttpContent httpContent, IDataProtectionProvider dataProtectionProvider)
        {
            _httpContent = httpContent;
            _dataProtectionProvider = dataProtectionProvider;
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

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
