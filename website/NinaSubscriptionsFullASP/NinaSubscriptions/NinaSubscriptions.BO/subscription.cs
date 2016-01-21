using System;
using System.Collections.Generic;
using System.Text;

namespace NinaSubscriptions.BO {

	public class subscription {

		public int id { get; set; }
		public course course { get; set; }
		public child child { get; set; }
		public bool paymentConfirmed { get; set; }

	}
}
