using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.Web.Models.Home;
using AutoRepairManagementStudio.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairManagementStudio.Web.Controllers
{
    /// <summary>
    /// Handles the query grid views. This is the default landing page after login, and provides quick access to common queries and reports.
    /// </summary>
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

        /// <summary>
        /// Handles the default home page request.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return WorkOrders();
        }

        /// <summary>
        /// Query Grid of the active work orders, with links to the details page for each item.
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkOrders()
        {
            WorkOrderGridModel model = service.GetWorkOrders();

            return View("~/Views/Home/WorkOrders.cshtml", model);
        }

        /// <summary>
        /// Query Grid of accounts, with links to the details page for each item.
        /// </summary>
        /// <returns></returns>
        public IActionResult Accounts()
        {
            AccountGridModel model = service.GetAccounts();

            return View("~/Views/Home/Accounts.cshtml", model);
        }

    }
}
