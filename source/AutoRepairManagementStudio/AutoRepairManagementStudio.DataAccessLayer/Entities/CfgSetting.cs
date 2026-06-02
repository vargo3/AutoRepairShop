using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.Entities
{
    [Table("cfg_setting")]
    public class CfgSetting
    {
        [Key]
        [Required]
        [MaxLength(64)]
        public required string name { get; set; }

        [Required]
        [MaxLength(64)]
        public required string value { get; set; }

    }
}
