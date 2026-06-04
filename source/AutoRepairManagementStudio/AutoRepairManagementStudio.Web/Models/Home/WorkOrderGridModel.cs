using AutoRepairManagementStudio.DataAccessLayer.ViewEntities;

namespace AutoRepairManagementStudio.Web.Models.Home
{
    public class WorkOrderGridModel
    {
        public WorkOrderView[] WorkOrders { get; set; } = Array.Empty<WorkOrderView>();
    }
}
