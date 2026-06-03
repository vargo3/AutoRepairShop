using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairManagementStudio.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        public VehicleController(AutoRepairContext context)
        {
            //service = new WorkOrderService(context);
        }

        #region Data Members
        //private WorkOrderService service { get; }
        #endregion Data Members


        public IActionResult Index()
        {
            return View();
        }

    }
}
