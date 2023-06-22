using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicCarRentAPI.Controllers
{
    public class ClientsController : Controller
    {
        private readonly AppDbContext db;

        public ClientsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: Clients
        public async Task<IActionResult> Index() => View(await db.Clients.ToListAsync());

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Clients == null) return NotFound();

            var client = await db.Clients.FirstOrDefaultAsync(m => m.Id == id);
            if (client == null) return NotFound();

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create() => View();

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Lastname,TotalBill,TotalPay,TotalDebt,TotalDrivingTime,Experience,Score,Id")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Clients == null) return NotFound();

            var client = await db.Clients.FindAsync(id);
            if (client == null) return NotFound();
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Lastname,TotalBill,TotalPay,TotalDebt,TotalDrivingTime,Experience,Score,Id")] Client client)
        {
            if (id != client.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(client);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Clients == null) return NotFound();

            Client? client = await db.Clients.FirstOrDefaultAsync(m => m.Id == id);
            if (client == null) return NotFound();

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Clients == null) return Problem("В БД нет клиентов");
            var client = await db.Clients.FindAsync(id);
            if (client != null) db.Clients.Remove(client);

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id) => (db.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
