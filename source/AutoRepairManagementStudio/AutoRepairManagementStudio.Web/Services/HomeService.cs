using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.DataAccessLayer.ViewEntities;
using AutoRepairManagementStudio.Web.Models;
using AutoRepairManagementStudio.Web.Models.Home;
using AutoRepairManagementStudio.Web.Models.WorkOrder;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairManagementStudio.Web.Services
{
    public class HomeService
    {
        public HomeService(AutoRepairContext context)
        {
            DataAccess = new AutoRepairDA(context);
        }

        #region Data Members
        private AutoRepairDA DataAccess { get; }
        #endregion Data Members


        public WorkOrderGridModel GetWorkOrders()
        {
            WorkOrderGridModel model = new WorkOrderGridModel();

            WorkOrderView[] WorkOrders = DataAccess.GetAllActiveWorkOrders();
            model.WorkOrders = WorkOrders;

            return model;
        }

        public AccountGridModel GetAccounts()
        {
            AccountGridModel model = new AccountGridModel();

            return model;
        }

    }
}
