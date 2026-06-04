using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairManagementStudio.DataAccessLayer.Entities
{
    [Table("cfg_vehicle_model")]
    public class CfgVehicleModel
    {
        [Key]
        [Required]
        public int cfg_vehicle_model_id { get; set; }

        [Required]
        [MaxLength(64)]
        public required string make { get; set; }

        [Required]
        [MaxLength(64)]
        public required string model { get; set; }

    }
}
