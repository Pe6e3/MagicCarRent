using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;
using MagicCarRentAPI.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MagicCarRentAPI.Controllers
{
    public class JournalController : Controller
    {
        private readonly AppDbContext db;

        public JournalController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: Journal
        public async Task<IActionResult> Index()
        {
            List<Journal> journal = await
                db.Journal
                .Include(c => c.Car)
                .Include(c => c.Client)
                .Include(d => d.Discount)
                .ToListAsync();
            return View(journal);
        }

        // GET: Journal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Journal == null) return NotFound();

            var journal = await db.Journal
                .Include(c => c.Car)
                .Include(c => c.Client)
                .Include(d => d.Discount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journal == null) return NotFound();

            return View(journal);
        }

        // GET: Journal/Create
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "ModelAndBrand");
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "FullName");
            ViewData["Discount"] = new SelectList(db.Discounts, "DiscountName", "DiscountRate");
            return View();
        }

        // POST: Journal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JournalDTO JournalDTO)
        {
            if (ModelState.IsValid)
            {
                Car car = await db.Cars.FirstOrDefaultAsync(c => c.Id == JournalDTO.CarID);
                Journal newLineJournal = new Journal();

                newLineJournal.Discount = await db.Discounts.FirstOrDefaultAsync(c => c.DiscountName == JournalDTO.DiscountName);
                newLineJournal.RentBill = (car.CostDay * (JournalDTO.EndRent.Value - JournalDTO.BeginRent.Value).TotalDays) * (1 - newLineJournal.Discount.DiscountRate);
                newLineJournal.BeginRent = JournalDTO.BeginRent;
                newLineJournal.EndRent = JournalDTO.EndRent;
                newLineJournal.CarID = JournalDTO.CarID;
                newLineJournal.ClientID = JournalDTO.ClientID;

                db.Add(newLineJournal);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "Brand");
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "Lastname");
            ViewData["Discount"] = new SelectList(db.Discounts, "DiscountName", "DiscountRate");

            return View(JournalDTO);
        }

        // GET: Journals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Journal == null) return NotFound();

            var journal = await db.Journal.FindAsync(id);
            if (journal == null) return NotFound();
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "Id", journal.CarID);
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "Id", journal.ClientID);
            return View(journal);
        }

        // POST: Journals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,CarID,BeginRent,EndRent,RentBill,Id")] Journal journal)
        {
            if (id != journal.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(journal);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalExists(journal.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(db.Cars, "Id", "Id", journal.CarID);
            ViewData["ClientID"] = new SelectList(db.Clients, "Id", "Id", journal.ClientID);
            return View(journal);
        }

        // GET: Journals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Journal == null) return NotFound();

            var journal = await db.Journal
                .Include(c => c.Car)
                .Include(c => c.Client)
                .Include(d => d.Discount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journal == null) return NotFound();

            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Journal == null) return Problem("Entity set 'AppDbContext.ClientJournals'  is null.");
            var journal = await db.Journal.FindAsync(id);
            if (journal != null) db.Journal.Remove(journal);

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalExists(int id) => (db.Journal?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
