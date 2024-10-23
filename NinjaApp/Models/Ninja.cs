using System.ComponentModel.DataAnnotations;

namespace NinjaApp.Models
{
    public class Ninja
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gold is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Amount of gold must be a positive value.")]
        public int AmountOfGold { get; set; }
        public virtual ICollection<NinjaEquipment> NinjaEquipments { get; set; }
        public Ninja()
        {
            NinjaEquipments = new List<NinjaEquipment>();
        }


    }
}
