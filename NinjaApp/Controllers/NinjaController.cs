using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaApp.Models;
using NinjaApp.DbAccess;
namespace NinjaApp.Controllers
{
    public class NinjaController : Controller
    {
        private readonly MyNinjaDbContext _context;
        public NinjaController(MyNinjaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(string searchQuery)
        {
            // get all ninjas from the database
            List<Ninja> ninjas = _context.Ninjas.ToList();

            // if the search query is not empty, filter the ninjas
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // filter the ninjas by the search query    
                ninjas = ninjas
                    .Where(n => n.Name
                    .Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                ViewData["SearchQuery"] = searchQuery; 
            }

            return View(ninjas);
        }
        public ActionResult Inventory(int id)
        {
            // get the equipment with the given id
            Ninja? ninja = _context.Ninjas
                .Include(n => n.NinjaEquipments)
                .ThenInclude(ne => ne.Equipment)
                .FirstOrDefault(n => n.Id == id);
            
            ViewData["EquipmentTypes"] = Enum.GetValues<EquipmentType>().Cast<EquipmentType>().ToList();
            return View(ninja);
        }
        public ActionResult EmptyInventory(int id)
        {
            // get the ninja with the given id
            Ninja? ninja = _context.Ninjas
                .Include(n => n.NinjaEquipments)
                .ThenInclude(ne => ne.Equipment)
                .FirstOrDefault(n => n.Id == id);
            int totalGold = 0;

            // if the ninja has no equipments, initialize the list
            if (ninja != null)
            {
                // remove all the ninja equipments
                foreach (var ninjaEquipment in ninja.NinjaEquipments.ToList())
                {
                    // add the gold worth of the equipment to the total gold
                    totalGold += ninjaEquipment.Equipment.GoldWorth;
                    _context.NinjaEquipments.Remove(ninjaEquipment);
                }
                // add the total gold to the ninja's gold
                ninja.AmountOfGold += totalGold;
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Inventory), new { id = id });
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(string name)
        {
            if (ModelState.IsValid)
            {
                // create a new ninja object
                Ninja ninja = new Ninja { 
                    AmountOfGold = 100, 
                    Name = name 
                };
                // add the ninja to the database
                _context.Ninjas.Add(ninja);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            Ninja? ninja = _context.Ninjas.FirstOrDefault(n => n.Id == id);
            return View(ninja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string name, int amountOfGold)
        {
            if (ModelState.IsValid)
            {
                // get the ninja with the given id
                Ninja? ninja = _context.Ninjas.FirstOrDefault(n => n.Id == id);
                if (ninja == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ninja.Name = name;
                ninja.AmountOfGold = amountOfGold;
                
                // update the ninja in the database
                _context.Entry(ninja).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            Ninja? ninja = _context.Ninjas.FirstOrDefault(n => n.Id == id);
            return View(ninja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, string name)
        {
            if (ModelState.IsValid)
            {
                // get the ninja with the given id
                Ninja? ninja = _context.Ninjas.FirstOrDefault(n => n.Id == id);
                if (ninja == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                // remove the ninja from the database
                _context.Ninjas.Remove(ninja);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
