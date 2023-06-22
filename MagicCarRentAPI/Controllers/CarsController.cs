using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicCarRentAPI.Controllers
{
    public class CarsController : Controller
    {
        private readonly AppDbContext db;

        public CarsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: Cars
        public async Task<IActionResult> Index() => View(await db.Cars.ToListAsync());

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Cars == null) return NotFound();

            var car = await db.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create() => View();

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Brand,Year,CarColor,CostHour,CostDay,TotalRentTime,TotalMoneyEarn,IsRentedNow,IsInService,Id")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Add(car);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Cars == null) return NotFound();
            Car? car = await db.Cars.FindAsync(id);
            if (car == null) return NotFound();
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Model,Brand,Year,CarColor,CostHour,CostDay,TotalRentTime,TotalMoneyEarn,IsRentedNow,IsInService,Id")] Car car)
        {
            if (id != car.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(car);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Cars == null) return NotFound();

            Car? car = await db.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Cars == null) return Problem("Entity set 'AppDbContext.Cars'  is null.");
            Car? car = await db.Cars.FindAsync(id);
            if (car != null) db.Cars.Remove(car);

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id) => (db.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
