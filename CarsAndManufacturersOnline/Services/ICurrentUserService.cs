using CarsAndManufacturersOnline.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Services
{
    public interface ICurrentUserService
    {
        Task<IEnumerable<Car>> GetAllCarsOfCurrentUser();
        Task<User> GetCurrentUser();
        Task<string> GetCurrentUserName();
        Task SetCurrentUser(string currentUserName);
    }
}