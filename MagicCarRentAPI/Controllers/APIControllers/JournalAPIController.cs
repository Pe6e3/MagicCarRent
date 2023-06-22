using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicCarRentAPI.Controllers.APIControllers;

[ApiController]
[Route("api/JournalAPI")]
public class JournalAPIController : ControllerBase
{
    private readonly AppDbContext db;
    public JournalAPIController(AppDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetJournal() => Ok(await db.Journal.Include("Car").ToListAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetLineJournal(int id) => Ok(await db.Journal.FirstOrDefaultAsync(j => j.Id == id));

    [HttpGet("{carModel}")]
    public async Task<IActionResult> GetLinesByCar([FromRoute] string carModel) => Ok(await db.Journal.Include(x => x.Car).Where(x => x.Car.Model == carModel).ToListAsync());

}