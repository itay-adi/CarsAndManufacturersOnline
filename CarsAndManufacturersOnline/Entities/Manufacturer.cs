using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Entities
{
    public record Manufacturer
    (
        String Name,
        String Country,
        int Year
    );
}
