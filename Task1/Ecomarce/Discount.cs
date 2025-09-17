using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal static class Discount
    {
        public static double GetDiscount(CustomerType customerType)
        {
            return customerType == CustomerType.VIP ? 0.30 : 0.20;
        }
    }
}
