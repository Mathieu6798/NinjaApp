using System.ComponentModel.DataAnnotations;

namespace NinjaApp.Models
{
    public enum EquipmentType
    {
        Head, 
        Chest, 
        Hand, 
        Feet, 
        Ring, 
        Necklace
    }

    public class Equipment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Equipment type is required.")]
        public EquipmentType Type { get; set; }
        [Required(ErrorMessage = "Gold is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Amount of gold must be a positive value.")]
        public int GoldWorth { get; set; }
        [Required(ErrorMessage = "Strength is required.")]
        public int Strength { get; set; }
        [Required(ErrorMessage = "Agility is required.")]
        public int Agility { get; set; }
        [Required(ErrorMessage = "Intelligence is required.")]
        public int Intelligence { get; set; }
        public virtual ICollection<NinjaEquipment> NinjaEquipments { get; set; }
    }
}
