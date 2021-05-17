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
    [Route("api/usercars")]
    [ApiController]
    public class UserCarsController : ControllerBase
    {
        private IRepositoryService _repo;

        public UserCarsController(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpPost("")]
        public async Task<ActionResult<UserCar>> AddUserCar(UserCar userCar)
        {
            try
            {
                var res = await _repo.AddUserCar(userCar);

                return CreatedAtRoute(nameof(userCar), new { UserCar = res.UserName }, res);
            }

            catch 
            {
                return BadRequest();
            }
        }

        [HttpDelete("{username}/{carId}")]
        public async Task<ActionResult> RemoveUserCar(string userName, Guid carId)
        {
            var value = new UserCar(UserName: userName, CarGuid: carId);

            try
            {
                await _repo.RemoveUserCar(value);

                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarsOfUser(string userName)
        {
            try
            {
                var CarsOfUser = await _repo.GetAllCarsOfUser(userName);

                return Ok(CarsOfUser);
            }

            catch
            {
                return NotFound();
            }
        } 
    }
}
