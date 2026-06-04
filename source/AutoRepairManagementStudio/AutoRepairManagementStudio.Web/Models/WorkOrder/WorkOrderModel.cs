using AutoRepairManagementStudio.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagementStudio.Web.Models.WorkOrder
{
    /// <summary>
    /// Edit Model for <see cref="AutoRepairManagementStudio.DataAccessLayer.Entities.WorkOrder">WorkOrder</see>
    /// </summary>
    public class WorkOrderModel
    {
        public int work_order_id { get; set; }

        [Display(Name = "Created At")]
        public DateTime created_at { get; set; } = DateTime.Now;

        [Display(Name = "Account")]
        public int account_id { get; set; }

        /// <summary>
        /// Existing work orders should never override vehicle_id. Use this only for creating new work orders.
        /// </summary>
        [Display(Name = "Vehicle")]
        public int vehicle_id { get; set; }

        public int cfg_status_id { get; set; }

        [Display(Name = "Description")]
        [MaxLength(512)]
        public string? description { get; set; }

        [Display(Name = "Notes")]
        public string? notes { get; set; }

        [Display(Name = "Account")]
        public string account_name { get; set; } = string.Empty;

        [Display(Name = "Vehicle")]
        public string vehicle_description { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public string status_description { get; set; } = string.Empty;

        public SelectListItem[] CfgStatuses { get; set; } = Array.Empty<SelectListItem>();
        public SelectListItem[] Accounts { get; set; } = Array.Empty<SelectListItem>();
        public SelectListItem[] Vehicles { get; set; } = Array.Empty<SelectListItem>();

    }
}
