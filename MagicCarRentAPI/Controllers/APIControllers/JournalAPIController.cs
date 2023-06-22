using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;
using MagicCarRentAPI.Entities.DTO;
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
    public async Task<IActionResult> GetLinesByCar([FromRoute] string carModel)
    {
        var journal = await db.Journal.Include(x => x.Car).Where(x => x.Car.Model == carModel).ToListAsync();
        if (journal.Count == 0) return BadRequest();
        return Ok(journal);
    }

    [HttpPost]
    public async Task<IActionResult> AddJournalLine(int clientID, int carID, DateTime beginRent, DateTime endRent)
    {
        Journal journal = new Journal()
        {
            ClientID = clientID,
            CarID = carID,
            BeginRent = beginRent,
            EndRent = endRent
        };

        db.Add(journal);
        await db.SaveChangesAsync();
        return Ok(journal);
    }

    //public async Task<IActionResult> AddJournalLine(int clientID, int carID, DateTime beginRent, DateTime endRent)
    //{
    //    JournalDTO journal = new JournalDTO()
    //    {
    //        ClientID = clientID,
    //        CarID = carID,
    //        BeginRent = beginRent,
    //        EndRent = endRent
    //    };
    //    using (HttpClient client = new HttpClient())
    //    {
    //        client.BaseAddress = new Uri("https://localhost:7067/Journal/Create/");

    //        var response = await client.PostAsJsonAsync("Journal/Create", journal);
    //        return Ok(journal);
    //    }
    //}
}