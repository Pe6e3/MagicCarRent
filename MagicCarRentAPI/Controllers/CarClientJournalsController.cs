using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;
using MagicCarRentAPI.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MagicCarRentAPI.Controllers
{
    public class CarClientJournalsController : Controller
    {
        private readonly AppDbContext db;

        public CarClientJournalsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: CarClientJournals
        public async Task<IActionResult> Index()
        {
            List<CarClientJournal> journal = await
                db.ClientJournals
                .Include(c => c.Car)
                .Include(c => c.Client)
                .Include(d => d.Discount)
                .ToListAsync();
            return View(journal);
        }

        // GET: CarClientJournals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.ClientJournals == null) return NotFound();

            var carClientJournal = await db.ClientJournals
                .Include(c => c.Car)
                .Include(c => c.Client)
                .Include(d => d.Discount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carClientJournal == null) return NotFound();

            return View(carClientJournal);
        }

        // GET: CarClientJournals/Create
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "ModelAndBrand");
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "FullName");
            ViewData["Discount"] = new SelectList(db.Discounts, "DiscountName", "DiscountRate");
            return View();
        }

        // POST: CarClientJournals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarClientJournalDTO carClientJournalDTO)
        {
            if (ModelState.IsValid)
            {
                Car car = await db.Cars.FirstOrDefaultAsync(c => c.Id == carClientJournalDTO.CarID);
                CarClientJournal newLineJournal = new CarClientJournal();

                newLineJournal.Discount = await db.Discounts.FirstOrDefaultAsync(c => c.DiscountName == carClientJournalDTO.DiscountName);
                newLineJournal.RentBill = (car.CostDay * (carClientJournalDTO.EndRent.Value - carClientJournalDTO.BeginRent.Value).TotalDays) * (1 - newLineJournal.Discount.DiscountRate);
                newLineJournal.BeginRent = carClientJournalDTO.BeginRent;
                newLineJournal.EndRent = carClientJournalDTO.EndRent;
                newLineJournal.CarID = carClientJournalDTO.CarID;
                newLineJournal.ClientID = carClientJournalDTO.ClientID;

                db.Add(newLineJournal);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "Brand");
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "Lastname");
            ViewData["Discount"] = new SelectList(db.Discounts, "DiscountName", "DiscountRate");

            return View(carClientJournalDTO);
        }

        // GET: CarClientJournals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.ClientJournals == null) return NotFound();

            var carClientJournal = await db.ClientJournals.FindAsync(id);
            if (carClientJournal == null) return NotFound();
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "Id", carClientJournal.CarID);
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "Id", carClientJournal.ClientID);
            return View(carClientJournal);
        }

        // POST: CarClientJournals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,CarID,BeginRent,EndRent,RentBill,Id")] CarClientJournal carClientJournal)
        {
            if (id != carClientJournal.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(carClientJournal);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarClientJournalExists(carClientJournal.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "Id", carClientJournal.CarID);
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "Id", carClientJournal.ClientID);
            return View(carClientJournal);
        }

        // GET: CarClientJournals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.ClientJournals == null) return NotFound();

            var carClientJournal = await db.ClientJournals
                .Include(c => c.Car)
                .Include(c => c.Client)
                .Include(d => d.Discount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carClientJournal == null) return NotFound();

            return View(carClientJournal);
        }

        // POST: CarClientJournals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.ClientJournals == null) return Problem("Entity set 'AppDbContext.ClientJournals'  is null.");
            var carClientJournal = await db.ClientJournals.FindAsync(id);
            if (carClientJournal != null) db.ClientJournals.Remove(carClientJournal);

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarClientJournalExists(int id) => (db.ClientJournals?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
