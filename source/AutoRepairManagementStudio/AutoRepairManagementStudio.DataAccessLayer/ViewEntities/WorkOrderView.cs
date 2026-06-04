using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.ViewEntities
{
    [Table("vw_work_order")]
    public class WorkOrderView
    {
        [Key]
        public int work_order_id { get; set; }

        public DateTimeOffset created_at { get; set; }

        public int account_id { get; set; }
        
        public int vehicle_id { get; set; }
        
        public int cfg_status_id { get; set; }
        
        [MaxLength(512)]
        public string? description { get; set; }
        
        public string? notes { get; set; }
        
        public required string account_name { get; set; }

        public required string vehicle_description { get; set; }

        public required string status_description { get; set; }

    }
}
