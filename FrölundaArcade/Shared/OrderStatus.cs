using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrölundaArcade.Shared
{
    public class OrderStatus
    {
        public enum Status
        {
            Behandlas,
            Skickad,
            Avbruten,
            Levererad
        }
    }
}
