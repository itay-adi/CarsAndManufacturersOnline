using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Entities
{
    public record User
    (
        string UserName,
        string FirstName,
        string LastName
    );
}
