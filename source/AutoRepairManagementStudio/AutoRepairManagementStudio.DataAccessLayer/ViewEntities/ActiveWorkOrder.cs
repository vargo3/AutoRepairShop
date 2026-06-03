using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.ViewEntities
{
    [Table("active_work_order")]
    public class ActiveWorkOrder
    {
        [Key]
        public int work_order_id { get; set; }
        public int account_id { get; set; }
        public int vehicle_id { get; set; }
        public required string account_name { get; set; }
        public short vechicle_year { get; set; }
        public required string vechicle_make { get; set; }
        public required string vechicle_model { get; set; }
        public DateTimeOffset created_at { get; set; }
        public required string status_description { get; set; }

    }
}
