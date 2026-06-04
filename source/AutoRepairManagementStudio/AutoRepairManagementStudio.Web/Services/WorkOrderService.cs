using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.DataAccessLayer.ViewEntities;
using AutoRepairManagementStudio.Web.Models;
using AutoRepairManagementStudio.Web.Models.Home;
using AutoRepairManagementStudio.Web.Models.WorkOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoRepairManagementStudio.Web.Services
{
    public class WorkOrderService
    {
        public WorkOrderService(AutoRepairContext context, int userId)
        {
            DataAccess = new AutoRepairDA(context);
            this.userId = userId;
        }

        #region Data Members
        private AutoRepairDA DataAccess { get; }
        private int userId { get; }
        #endregion Data Members


        public WorkOrderModel GetWorkOrder(int? work_order_id)
        {
            WorkOrderModel model = new WorkOrderModel();

            WorkOrderView? order = DataAccess.GetWorkOrderView(work_order_id);
            CfgStatus[] statuses = DataAccess.GetAllCfgStatuses();
            Account[] accounts = DataAccess.GetAllAccounts();
            Vehicle[] vehicles = DataAccess.GetAllVehicles();
            CfgVehicleModel[] vehicleModels = DataAccess.GetAllCfgVehicleModels();

            model.CfgStatuses = statuses.Select(s => new SelectListItem
            {
                Value = s.cfg_status_id.ToString(),
                Text = s.description,
                Selected = (s.cfg_status_id == order?.cfg_status_id),
            }).ToArray();

            model.Accounts = accounts.Select(s => new SelectListItem
            {
                Value = s.account_id.ToString(),
                Text = $"{s.first_name} {s.last_name}",
                Selected = (s.account_id == order?.account_id),
            }).ToArray();

            model.Vehicles = new SelectListItem[vehicles.Length];
            for(int i = 0; i < vehicles.Length; i++)
            {
                var vehicleModel = vehicleModels.First(x => x.cfg_vehicle_model_id == vehicles[i].cfg_vehicle_model_id);
                model.Vehicles[i] = new SelectListItem
                {
                    Value = vehicles[i].vehicle_id.ToString(),
                    Text = $"{vehicles[i].year} {vehicleModel.make} {vehicleModel.model}",
                    Selected = (vehicles[i].vehicle_id == order?.vehicle_id),
                };
            }

            if (order == null) return model;

            model.work_order_id = order.work_order_id;
            model.created_at = order.created_at.LocalDateTime;
            model.account_id = order.account_id;
            model.vehicle_id = order.vehicle_id;
            model.cfg_status_id = order.cfg_status_id;
            model.description = order.description;
            model.notes = order.notes;
            model.account_name = order.account_name;
            model.vehicle_description = order.vehicle_description;

            return model;
        }

        public int SaveProfile(WorkOrderModel model)
        {
            WorkOrder order = DataAccess.UpdateWorkOrder(model.work_order_id, userId, model.account_id, model.vehicle_id, model.cfg_status_id, model.description, model.notes);
            return order.work_order_id;
        }

    }
}
