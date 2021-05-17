using CarsAndManufacturersOnline.Entities;
using CarsAndManufacturersOnline.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Services
{
    public class DataReaderService : IDataReaderService
    {
        private const string _carsFile = "Cars.csv";
        private const string _basePath = "Data";
        private const string _mfgFile = "Manufacturers.csv";

        public Task<IEnumerable<Car>> GetAllCars()
        {
            var carList = File.ReadAllLines($"{_basePath}/{_carsFile}")
                .Skip(1)
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToCar());

            return Task.FromResult(carList);
        }

        public Task<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            var ManufacturerList = File.ReadAllLines($"{_basePath}/{_mfgFile}")
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => str.ToManufacturer());

            return Task.FromResult(ManufacturerList);
        }
    }
}
