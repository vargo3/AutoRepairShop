using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.Web.Models;
using AutoRepairManagementStudio.Web.Models.Account;
using AutoRepairManagementStudio.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AutoRepairManagementStudio.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController(AutoRepairContext context)
        {
            service = new AccountService(context);
        }

        #region Data Members
        private AccountService service { get; }
        #endregion Data Members


        #region Auth methods
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string? errorMessage = service.ValidateLogin(model);

            if (errorMessage != null)
            {
                ViewBag.ErrorMessage = errorMessage;
                //ModelState.AddModelError("", "Invalid credentials.");
                return Login();
            }
            else //pass auth
            {
                // Build the user identity info
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, model.Username),
                    //new Claim(ClaimTypes.NameIdentifier, "1"),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Issue the cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        #endregion Auth methods

        /// <summary>
        /// Account profile page, with options to change password, view associated vehicles, view open work orders, etc. (not fully implemented yet)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Account/Index.cshtml");
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
