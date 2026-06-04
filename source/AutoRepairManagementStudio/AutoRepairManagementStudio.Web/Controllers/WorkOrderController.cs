using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.Web.Models.WorkOrder;
using AutoRepairManagementStudio.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoRepairManagementStudio.Web.Controllers
{
    [Authorize]
    public class WorkOrderController : Controller
    {
        public WorkOrderController(AutoRepairContext context)
        {
            //userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            userId = 1; //TODO: Remove hardcoded userId and get from auth context once auth is implemented

            service = new WorkOrderService(context, userId);
        }

        #region Data Members
        private WorkOrderService service { get; }
        private int userId { get; }
        #endregion Data Members


        public IActionResult Index(int? id)
        {
            WorkOrderModel model = service.GetWorkOrder(id);

            return View("~/Views/WorkOrder/WorkOrderProfile.cshtml", model);
        }

        public IActionResult SaveProfile(WorkOrderModel model)
        {
            service.SaveProfile(model);

            return RedirectToAction("Index", "WorkOrder", new { id = model.work_order_id });
        }
    }
}
