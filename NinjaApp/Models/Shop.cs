namespace NinjaApp.Models
{
    public class Shop
    {
        public Ninja Ninja { get; set; }
        public List<EquipmentType> Categories { get; set; }
    }

    public class ShopCategory
    {
        public Ninja Ninja { get; set; }
        public List<Equipment> Equipment { get; set; }
        public EquipmentType SelectedCategory { get; set; }
    }

}
