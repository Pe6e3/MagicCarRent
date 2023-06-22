using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;

namespace MagicCarRentAPI.Controllers
{
    public class DiscountsController : Controller
    {
        private readonly AppDbContext db;

        public DiscountsController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: Discounts
        public async Task<IActionResult> Index()
        {
              return db.Discounts != null ? 
                          View(await db.Discounts.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Discounts'  is null.");
        }

        // GET: Discounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Discounts == null)
            {
                return NotFound();
            }

            var discount = await db.Discounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        // GET: Discounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Discounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscountName,DiscountRate,Id")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                db.Add(discount);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discount);
        }

        // GET: Discounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Discounts == null)
            {
                return NotFound();
            }

            var discount = await db.Discounts.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        // POST: Discounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiscountName,DiscountRate,Id")] Discount discount)
        {
            if (id != discount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(discount);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountExists(discount.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(discount);
        }

        // GET: Discounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Discounts == null)
            {
                return NotFound();
            }

            var discount = await db.Discounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        // POST: Discounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Discounts == null)
            {
                return Problem("Entity set 'AppDbContext.Discounts'  is null.");
            }
            var discount = await db.Discounts.FindAsync(id);
            if (discount != null)
            {
                db.Discounts.Remove(discount);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountExists(int id)
        {
          return (db.Discounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
