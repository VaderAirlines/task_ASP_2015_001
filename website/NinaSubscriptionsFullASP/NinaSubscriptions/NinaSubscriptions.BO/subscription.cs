using System;
using System.Collections.Generic;
using System.Text;

namespace NinaSubscriptions.BO {

	public class subscription {

		public int id { get; set; }
		public course course { get; set; }
		public List<child> children { get; set; }
		public bool paymentConfirmed { get; set; }

	}
}
