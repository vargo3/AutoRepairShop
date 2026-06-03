using AutoRepairManagementStudio.DataAccessLayer.ViewEntities;

namespace AutoRepairManagementStudio.Web.Models.Home
{
    public class WorkOrderGridModel
    {
        public List<ActiveWorkOrder> WorkOrders { get; set; } = new List<ActiveWorkOrder>();
    }
}
