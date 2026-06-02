using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairManagementStudio.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController(AutoRepairContext context)
        {
            service = new HomeService(context);
        }

        #region Data Members
        private HomeService service { get; }
        #endregion Data Members


        public IActionResult Index()
        {
            return View();
        }

    }
}
