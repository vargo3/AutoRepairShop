using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.Entities
{
    [Table("cfg_status")]
    public class CfgStatus
    {
        [Key]
        [Required]
        public int cfg_status_id { get; set; }

        [Required]
        [MaxLength(24)]
        public required string description { get; set; }

        [Required]
        public int display_order { get; set; }

    }
}
