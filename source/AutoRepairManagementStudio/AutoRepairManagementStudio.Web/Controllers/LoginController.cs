using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.Web.Models;
using AutoRepairManagementStudio.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AutoRepairManagementStudio.Web.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(AutoRepairContext context)
        {
            service = new LoginService(context);
        }

        #region Data Members
        private LoginService service { get; }
        #endregion Data Members


        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Login/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string? errorMessage = service.ValidateLogin(model);

            if (errorMessage != null)
            {
                ViewBag.ErrorMessage = errorMessage;
                //ModelState.AddModelError("", "Invalid credentials.");
                return Index();
            }
            else //pass auth
            {
                // Build the user identity info
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Username) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Issue the cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
