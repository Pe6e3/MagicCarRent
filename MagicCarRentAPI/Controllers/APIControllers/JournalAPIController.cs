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
    public async Task<IActionResult> GetJournal()
    {
        IEnumerable<Journal> journal = await db.Journal.ToListAsync();

        return Ok(journal);
    }

    //[HttpGet]
    //public IEnumerable<Villa> GetVillas()
    //{
    //    return new List<Villa>{
    //        new Villa()
    //        {
    //            Id = 1,
    //            Name = "Pool View"
    //        },
    //        new Villa()
    //        {
    //            Id = 2,
    //            Name = "Beach View"
    //        },
    //            new Villa()
    //        {
    //            Id = 3,
    //            Name = "Sky View"
    //        }

    //    };

    //}
}