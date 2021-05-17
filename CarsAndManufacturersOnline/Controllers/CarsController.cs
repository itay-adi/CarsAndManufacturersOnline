using CarsAndManufacturersOnline.Entities;
using CarsAndManufacturersOnline.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IRepositoryService _repo;

        public CarsController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars([FromQuery] string division,
                                                                     [FromServices] ICurrentUserService currentUser)
        {
            var userName = await currentUser.GetCurrentUserName();
            IEnumerable<Car> res = Enumerable.Empty<Car>();

            if(string.IsNullOrWhiteSpace(userName))
            {
                res = await _repo.GetAllCars();
            }

            else
            {
                res = await _repo.GetAllCarsOfUser(userName);
            }

            if(!string.IsNullOrWhiteSpace(division))
            {
                res = res.Where(c => c.Division == division);
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(Guid id)
        {
            try
            {
                var car = await _repo.GetCarById(id);

                return Ok(car);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
