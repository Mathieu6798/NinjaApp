namespace NinjaApp.Models
{
    public class Shop
    {
        public Ninja Ninja { get; set; } = null!;
        public List<EquipmentType> Categories { get; set; } = null!;
    }

    public class ShopCategory
    {
        public Ninja Ninja { get; set; } = null!;
        public List<Equipment> Equipment { get; set; } = null!;
        public EquipmentType SelectedCategory { get; set; }
    }

}
