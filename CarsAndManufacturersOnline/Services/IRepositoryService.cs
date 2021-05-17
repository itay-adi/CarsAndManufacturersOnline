using CarsAndManufacturersOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Services
{
    public interface IRepositoryService
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(Guid id);
        Task<IEnumerable<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer> GetManufacturerByName(string name);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByName(string userName);
        Task<IEnumerable<UserCar>> GetAllUserCars();

        //CRUD operations
        Task<User> AddUser(User user);
        Task<User> ModifyUser(User user);
        Task DeleteUser(string userName);

        //operations for UserCar
        Task<UserCar> AddUserCar(UserCar userCar);
        Task RemoveUserCar(UserCar userCar);
        Task<IEnumerable<Car>> GetAllCarsOfUser(string userName);
        Task<IEnumerable<User>> GetAllUsersOfCar(Guid carId);
    }
}
