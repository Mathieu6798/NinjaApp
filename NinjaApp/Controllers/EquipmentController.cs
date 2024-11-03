using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaApp.Models;
using NinjaApp.DbAccess;
using System.Linq;
namespace NinjaApp.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly MyNinjaDbContext _context;
        public EquipmentController(MyNinjaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(string searchQuery)
        {
            // Fetch all equipment from the database
            var equipment = _context.Equipments.ToList();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Search
                equipment = equipment.Where(n => n.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                ViewData["SearchQuery"] = searchQuery;
            }

            return View(equipment);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Equipment model)
        {
            Equipment equipment = new Equipment
            {
                Name = model.Name,
                GoldWorth = model.GoldWorth,
                Agility = model.Agility,
                Intelligence = model.Intelligence,
                Strength = model.Strength,
                Type = model.Type
            };
            _context.Equipments.Add(equipment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var equipment = _context.Equipments.Find(id);
            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string name, int amountOfGold, int strength, int agility, int intelligence)
        {
            if (ModelState.IsValid)
            {
                Equipment? equipment = _context.Equipments.FirstOrDefault(n => n.Id == id);
                if (equipment == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                equipment.Name = name;
                equipment.GoldWorth = amountOfGold;
                equipment.Strength = strength;
                equipment.Agility = agility;
                equipment.Intelligence = intelligence;

                _context.Entry(equipment).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(name);
        }
        public ActionResult Delete(int id)
        {
            Equipment? equipment = _context.Equipments.FirstOrDefault(n => n.Id == id);
            // Ninjas out of the database like this otherwise the ninjaequipments will be null
            List<Ninja> ninjas = _context.Ninjas
            .Include(n => n.NinjaEquipments)
            .ThenInclude(ne => ne.Equipment)
            .ToList();
            EquipmentViewModel equipmentViewModel = new EquipmentViewModel(equipment, ninjas);
            return View(equipmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, string name, List<Ninja> ninjas)
        {
            // Fetch the equipment along with its associated NinjaEquipments and Ninjas
                Equipment? equipment = _context.Equipments
                    .Include(e => e.NinjaEquipments)
                    .ThenInclude(ne => ne.Ninja)
                    .FirstOrDefault(e => e.Id == id);

                if (equipment != null)
                {
                    foreach (var ninjaEquipment in equipment.NinjaEquipments)
                    {
                        // Deletes item and return users gold.
                        ninjaEquipment.Ninja.AmountOfGold += equipment.GoldWorth;
                        _context.NinjaEquipments.Remove(ninjaEquipment);
                    }
                    _context.Equipments.Remove(equipment);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
    }
}
