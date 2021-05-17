using CarsAndManufacturersOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Services
{
    public interface IDataReaderService
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<IEnumerable<Manufacturer>> GetAllManufacturers();
    }
}
