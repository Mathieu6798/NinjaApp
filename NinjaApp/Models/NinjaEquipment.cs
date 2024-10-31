using System.ComponentModel.DataAnnotations;

namespace NinjaApp.Models
{
    public class NinjaEquipment
    {
        [Key]
        public int NinjaId { get; set; }
        [Key]
        public int EquipmentId { get; set; }
        [Required]
        public Ninja Ninja { get; set; } = null!;
        [Required]
        public Equipment Equipment { get; set; } = null!;
    }
}