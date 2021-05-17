using CarsAndManufacturersOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Services
{
    public class RepositoryService : IRepositoryService
    {
        private Dictionary<string, User> _users = new();
        private HashSet<UserCar> _userCars = new();
        private Dictionary<Guid, Car> _cars;
        private Dictionary<string, Manufacturer> _manufacturers;
        private IDataReaderService _dataReader;
        private bool _isDataLoaded = false;

        public RepositoryService(IDataReaderService dataReader)
        {
            _dataReader = dataReader;
        }

        private async Task _LoadData()
        {
            if (_isDataLoaded)
            {
                return;
            }

            _isDataLoaded = true;
            _cars = (await _dataReader.GetAllCars()).ToDictionary(c => c.Id);
            _manufacturers = (await _dataReader.GetAllManufacturers()).ToDictionary(m => m.Name);
        }

        public Task<User> AddUser(User user)
        {
            if (_users.ContainsKey(user.UserName)) 
            {
                throw new ArgumentException($"Username:{user.UserName} is already existing");
            }

            _users.Add(user.UserName, user);

            return Task.FromResult(user);
        }

        public async Task<UserCar> AddUserCar(UserCar userCar)
        {
            await _LoadData();

            if(_userCars.Contains(userCar))
            {
                throw new ArgumentException($"UserCar:{userCar.UserName} is already existing");
            }

            if(!_users.ContainsKey(userCar.UserName))
            {
                throw new ArgumentException($"Username:{userCar.UserName} doesnt exists");
            }

            if (!_cars.ContainsKey(userCar.CarGuid))
            {
                throw new ArgumentException($"Car:{userCar.CarGuid} doesnt exists");
            }

            _userCars.Add(userCar);

            return userCar;
        }

        public Task DeleteUser(string userName)
        {
            if (!_users.ContainsKey(userName))
            {
                throw new ArgumentException($"Username:{userName} doesnt exists");
            }

            _users.Remove(userName);

            _userCars.RemoveWhere(uc => uc.UserName == userName);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            await _LoadData();

            return _cars.Values.ToList();
        }

        public async Task<IEnumerable<Car>> GetAllCarsOfUser(string userName)
        {
            await _LoadData();

            return _userCars
                .Where(uc => uc.UserName == userName)
                .Select(uc => _cars[uc.CarGuid]);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            await _LoadData();

            return _manufacturers.Values.ToList();
        }

        public async Task<IEnumerable<UserCar>> GetAllUserCars()
        {
            await _LoadData();

            return _userCars.ToList();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            await _LoadData();

            return _users.Values.ToList();
        }

        public async Task<IEnumerable<User>> GetAllUsersOfCar(Guid carId)
        {
            await _LoadData();

            return _userCars
                .Where(uc => uc.CarGuid == carId)
                .Select(uc => _users[uc.UserName]);
        }

        public async Task<Car> GetCarById(Guid id)
        {
            await _LoadData();

            return _cars[id];
        }

        public async Task<Manufacturer> GetManufacturerByName(string name)
        {
            await _LoadData();

            return _manufacturers[name];
        }

        public async Task<User> GetUserByName(string userName)
        {
            await _LoadData();

            return _users[userName];
        }

        public async Task<User> ModifyUser(User user)
        {
            await _LoadData();

            if (!_users.ContainsKey(user.UserName))
            {
                throw new ArgumentException($"Username:{user.UserName} doesnt exists");
            }

            _users[user.UserName] = user;

            return user;
        }

        public Task RemoveUserCar(UserCar userCar)
        {
            if (!_userCars.Contains(userCar))
            {
                throw new ArgumentException($"Could not find a record with car = {userCar.CarGuid} and user = {userCar.UserName}");
            }

            _userCars.Remove(userCar);

            return Task.CompletedTask;
        }
    }
}