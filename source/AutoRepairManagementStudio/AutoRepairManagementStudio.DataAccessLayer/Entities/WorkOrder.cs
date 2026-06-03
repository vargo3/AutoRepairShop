using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.Entities
{
    [Table("work_order")]
    public class WorkOrder
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int work_order_id { get; set; }

        [Required]
        public DateTimeOffset created_at { get; set; }

        [Required]
        public int created_by { get; set; }

        [Required]
        public DateTimeOffset updated_at { get; set; }

        [Required]
        public int updated_by { get; set; }

        [Required]
        public int account_id { get; set; }

        [Required]
        public int vehicle_id { get; set; }

        [Required]
        public int cfg_status_id { get; set; }

        [MaxLength(512)]
        public string? description { get; set; }

        public string? notes { get; set; }

    }
}
