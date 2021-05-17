using CarsAndManufacturersOnline.Entities;
using CarsAndManufacturersOnline.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Controllers
{
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private IRepositoryService _repo;
        public ManufacturersController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAllManufacturers()
        {
            var manufacturers = await _repo.GetAllManufacturers();

            return Ok(manufacturers);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturers(string name)
        {
            try
            {
                var manufacturer = await _repo.GetManufacturerByName(name);

                return Ok(manufacturer);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
