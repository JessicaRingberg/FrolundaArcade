using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrölundaArcade.Shared
{
    public class AddressDetails
    {
        [Required(AllowEmptyStrings = false)]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Zipcode { get; set; }
    }
}
