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
        [Key]
        [Range(1, int.MaxValue)]
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Equipment type is required.")]
        public EquipmentType Type { get; set; } = EquipmentType.Head;
        [Required(ErrorMessage = "Gold is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Amount of gold must be a positive value.")]
        public int GoldWorth { get; set; } = 0;
        [Required(ErrorMessage = "Strength is required.")]
        [Range(1, int.MaxValue)]
        public int Strength { get; set; } = 0;
        [Required(ErrorMessage = "Agility is required.")]
        [Range(1, int.MaxValue)]
        public int Agility { get; set; } = 0;
        [Required(ErrorMessage = "Intelligence is required.")]
        [Range(1, int.MaxValue)]
        public int Intelligence { get; set; } = 0;
        [Required]
        public virtual ICollection<NinjaEquipment> NinjaEquipments { get; set; } = new List<NinjaEquipment>();
        public Equipment()
        {
        }
        public Equipment(int id, string name, EquipmentType type, int goldWorth, int strength, int agility, int intelligence)
        {
            Id = id;
            Name = name;
            Type = type;
            GoldWorth = goldWorth;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
        }
    }
}
