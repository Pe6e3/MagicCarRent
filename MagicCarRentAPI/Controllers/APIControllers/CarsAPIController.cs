using MagicCarRentAPI.Data;
using MagicCarRentAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicCarRentAPI.Controllers.APIControllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarsAPIController : ControllerBase
    {
        private readonly AppDbContext db;
        public CarsAPIController(AppDbContext db)
        {
            this.db = db;
        }

        // GET: api/<CarsAPIController>
        [HttpGet]
        public async Task<IActionResult> GetCars() => Ok(await db.Cars.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            db.Add(car);
            await db.SaveChangesAsync();

            return Ok(car);
        }
    }
}
