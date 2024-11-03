using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace NinjaApp.Models
{
    public class Ninja
    {
        [Key]
        [Range(1, int.MaxValue)]
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = "Gold is required.")]
        [Range(0, 1000000, ErrorMessage = "Amount of gold must be a positive value and lower or equal to 1 million.")]
        public int AmountOfGold { get; set; } = 0;
        public virtual ICollection<NinjaEquipment> NinjaEquipments { get; set; } = new List<NinjaEquipment>();
        public Ninja()
        {
        }
        public Ninja(int id, string name, int amountOfGold)
        {
            Id = id;
            Name = name;
            AmountOfGold = amountOfGold;
        }

    }
}
