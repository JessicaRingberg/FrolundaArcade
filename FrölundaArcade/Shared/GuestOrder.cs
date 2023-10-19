using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrölundaArcade.Shared
{
	public class GuestOrder
	{
		public List<CartGame> Games { get; set; } = new();
		public GuestInfo Register { get; set; }
	}
}
