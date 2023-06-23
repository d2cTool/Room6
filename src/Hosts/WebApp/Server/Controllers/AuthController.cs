using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Shared.Authorization;

namespace WebApp.Server.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("~/login")]
        public IActionResult Login(string returnUrl = "/") =>
            Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, "github");

        [Authorize]
        [HttpGet("~/logout")]
        [HttpPost("~/logout")]
        public IActionResult Logout(string returnUrl = "/") =>
            SignOut(new AuthenticationProperties { RedirectUri = returnUrl }, CookieAuthenticationDefaults.AuthenticationScheme);

        [AllowAnonymous]
        [HttpGet("~/info")]
        public IActionResult Info()
        {
            var isAuthenticated = User.Identity?.IsAuthenticated;
            if (User.Identity?.IsAuthenticated ?? false)
            {
                HttpContext.GetTokenAsync("access_token");
                return Ok(new UserInfo
                {
                    Claims = HttpContext.User.Claims.Select(c => new ClaimValue(c.Type, c.Value)).ToArray(),
                    IsAuthenticated = true,
                    NameClaimType = "",
                    RoleClaimType = ""
                });
            }

            return Ok(UserInfo.Anonymous);
        }
    }
}
