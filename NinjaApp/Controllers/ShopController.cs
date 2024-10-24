using Microsoft.AspNetCore.Mvc;
using NinjaApp.DbAccess;
using NinjaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace NinjaApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyNinjaDbContext _context;

        public ShopController(MyNinjaDbContext context)
        {
            // initialize the context
            _context = context;
        }

        public IActionResult Index(int id)
        {
            // get the ninja with the given id
            var ninja = _context.Ninjas
            .Include(n => n.NinjaEquipments)
            .FirstOrDefault(n => n.Id == id);
            if (ninja == null)
            {
                return NotFound();
            }
            
            //create a new Shop object, distict for removing duplicate equipment types
            var viewModel = new Shop
            {
                Ninja = ninja,
                Categories = _context.Equipments
                .Select(e => e.Type)
                .Distinct()
                .ToList()
            };

            return View(viewModel);
        }

        public IActionResult ViewByCategory(int ninjaId, EquipmentType type)
        {
            // get the ninja with the given id
            var ninja = _context.Ninjas
                                .Include(n => n.NinjaEquipments)
                                .ThenInclude(ne => ne.Equipment)
                                .FirstOrDefault(n => n.Id == ninjaId);

            if (ninja == null)
            {
                return NotFound();
            }

            // if the ninja has no equipments, initialize the list
            ninja.NinjaEquipments = ninja.NinjaEquipments ?? new List<NinjaEquipment>();

            var equipment = _context.Equipments
                .Where(e => e.Type == type)
                .ToList();

            // create a new ShopCategory object
            var viewModel = new ShopCategory
            {
                Ninja = ninja,
                Equipment = equipment,
                SelectedCategory = type
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Buy(int ninjaId, int equipmentId)
        {
            // get the ninja with the given id
            var ninja = _context.Ninjas
                 .Include(n => n.NinjaEquipments)
                 .ThenInclude(ne => ne.Equipment)
                 .FirstOrDefault(n => n.Id == ninjaId);
            var equipment = _context.Equipments.Find(equipmentId);

            if (ninja == null || equipment == null)
            {
                return NotFound();
            }
            
            // check if the ninja has enough gold to buy the equipment
            if (ninja.AmountOfGold < equipment.GoldWorth)
            {
                TempData["ErrorMessage"] = "Not enough gold!";
                return RedirectToAction(nameof(ViewByCategory), new { ninjaId = ninjaId, type = equipment.Type });
            }

            // check if the ninja already has an item in this category
            if (ninja.NinjaEquipments.Any(i => i.Equipment.Type == equipment.Type))
            {
                TempData["ErrorMessage"] = "Ninja already has an item in this category!";
                return RedirectToAction(nameof(ViewByCategory), new { ninjaId = ninjaId, type = equipment.Type });
            }

            // create a new NinjaEquipment object
            var ninjaEquipment = new NinjaEquipment
            {
                NinjaId = ninjaId,
                EquipmentId = equipmentId,
                Ninja = ninja,
                Equipment = equipment
            };

            // add the equipment to the ninja's equipments
            ninja.NinjaEquipments.Add(ninjaEquipment);
            ninja.AmountOfGold -= equipment.GoldWorth;

            // save the changes to database
            _context.SaveChanges();

            return RedirectToAction(nameof(ViewByCategory), new { ninjaId = ninjaId, type = ninjaEquipment.Equipment.Type});
        }

        [HttpPost]
        public IActionResult Sell(int ninjaId, int equipmentId)
        {
            // get the ninja with the given id
            var ninja = _context.Ninjas.Include(n => n.NinjaEquipments).FirstOrDefault(n => n.Id == ninjaId);
            var ninjaEquipment = _context.NinjaEquipments
                .Include(ne => ne.Equipment)
                .FirstOrDefault(ne => ne.NinjaId == ninjaId && ne.EquipmentId == equipmentId);

            // check if the ninja and the equipment exist
            if (ninja == null || ninjaEquipment == null)
            {
                return NotFound();
            }

            // remove the equipment from the ninja's equipments
            ninja.NinjaEquipments.Remove(ninjaEquipment);

            // add the gold worth of the equipment to the ninja's gold
            ninja.AmountOfGold += ninjaEquipment.Equipment.GoldWorth;

            // save the changes to database
            _context.SaveChanges();

            return RedirectToAction(nameof(ViewByCategory), new { ninjaId = ninjaId, type = ninjaEquipment.Equipment.Type });
        }
    }

}
