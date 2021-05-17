using CarsAndManufacturersOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private IRepositoryService _repo;
        private string _currentUserName;

        public CurrentUserService(IRepositoryService repo)
        {
            _repo = repo;
        }

        public Task SetCurrentUser(string currentUserName)
        {
            _currentUserName = currentUserName;

            return Task.CompletedTask;
        }

        public Task<string> GetCurrentUserName()
        {
            return Task.FromResult(_currentUserName);
        }

        public Task<User> GetCurrentUser()
        {
            return _repo.GetUserByName(_currentUserName);
        }

        public Task<IEnumerable<Car>> GetAllCarsOfCurrentUser()
        {
            return _repo.GetAllCarsOfUser(_currentUserName);
        }
    }
}
