using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.Entities
{
    [Table("work_order_expense")]
    public class WorkOrderExpense
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int work_order_expense_id { get; set; }

        [Required]
        public DateTimeOffset created_at { get; set; }

        [Required]
        public int created_by { get; set; }

        [Required]
        public DateTimeOffset updated_at { get; set; }

        [Required]
        public int updated_by { get; set; }

        [Required]
        public int work_order_id { get; set; }

        [Required]
        public int cfg_status_id { get; set; }

        [Required]
        [MaxLength(64)]
        public required string description { get; set; }

        [Required]
        public decimal amount { get; set; }

        public DateTimeOffset? performed_at { get; set; }

        public int? performed_by_id { get; set; }

        public string? notes { get; set; }

    }
}
