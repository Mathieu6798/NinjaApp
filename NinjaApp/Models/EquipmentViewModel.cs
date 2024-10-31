using NinjaApp.Models;

public class EquipmentViewModel
{
    public Equipment Equipment { get; set; }
    public List<Ninja> UsedByNinjas { get; set; }

    public EquipmentViewModel(Equipment equipment, List<Ninja> ninjas)
    {
        Equipment = equipment;
        UsedByNinjas = GetNinjas(ninjas) ?? new List<Ninja>();
    }


    private List<Ninja> GetNinjas(List<Ninja> ninjas)
    {
        List<Ninja> ninjasWithEquipment = new List<Ninja>();
        foreach (Ninja ninja in ninjas)
        {
            foreach (var ninjaEquipment in ninja.NinjaEquipments)
            {
                if (ninjaEquipment.Equipment.Id == Equipment.Id)
                {
                    ninjasWithEquipment.Add(ninja);
                }
            }
        }
        return ninjasWithEquipment;
    }
}
