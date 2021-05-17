using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Entities
{
    public record Car
    (
        Guid Id,
        int ModelYear,
        string Division,
        String CarLine,
        Double EngineDisplacement,
        int Cylinders,
        int CityGasEfficiency,
        int HighWayGasEfficiency,
        int CombinedGasEfficiency
    );
}
