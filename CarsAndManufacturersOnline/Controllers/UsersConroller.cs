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
    [Route("api/users")]
    [ApiController]
    public class UsersConroller : ControllerBase
    {
        private IRepositoryService _repo;

        public UsersConroller(IRepositoryService repo)
        {
            _repo = repo;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUser(string userName)
        {
            try
            {
                var user = await _repo.GetUserByName(userName);

                return Ok(user);
            }

            catch
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                var res = await _repo.AddUser(user);

                return CreatedAtRoute(nameof(GetUser), new { UserName = res.UserName }, res);
            }

            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("")]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            try
            {
                await _repo.DeleteUser(userName);

                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }
    }
}
