using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcApp.Models.Enums
{
    public enum SaleStatus : int
    {
        PENDING = 1,
        BILLED = 2,
        CANCELED = 3
    }
}
