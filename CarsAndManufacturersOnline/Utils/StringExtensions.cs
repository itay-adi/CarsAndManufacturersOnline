using CarsAndManufacturersOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Utils
{
    public static class StringExtensions
    {
        public static string[] toColumns(this string source)
        {
            return source
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();
        }

        public static Car ToCar(this string source)
        {
            var carString = source.toColumns();

            if (carString.Length > 0)
            {
                return new Car(
                    Id: Guid.NewGuid(),
                    ModelYear : int.Parse(carString[0]),
                    Division : carString[1],
                    CarLine : carString[2],
                    EngineDisplacement : Double.Parse(carString[3]),
                    Cylinders : int.Parse(carString[4]),
                    CityGasEfficiency : int.Parse(carString[5]),
                    HighWayGasEfficiency : int.Parse(carString[6]),
                    CombinedGasEfficiency: int.Parse(carString[7])
                );
            }

            return null;
        }

        public static Manufacturer ToManufacturer(this string source)
        {
            var manufacturerString = source.toColumns();

            if (manufacturerString.Length > 0)
            {
                return new Manufacturer(
                    Name: manufacturerString[0],
                    Country: manufacturerString[1],
                    Year: int.Parse(manufacturerString[2])
                    );
            }

            return null;
        }
    }
}