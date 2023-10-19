using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrölundaArcade.Shared
{
    public class ShippingCosts
    {
        public double TotalPrice { get; set; }
        public double HomeDelivery { get; set; } = 49;
        public double StoreCollect { get; set; } = 0;
    }
}
