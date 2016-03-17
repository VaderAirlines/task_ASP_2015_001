using System;
using System.Collections.Generic;
using System.Text;

namespace NinaSubscriptions.BO {

	public class course {

		public int id { get; set; }
		public courseType courseType { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDateInclusive { get; set; }
		public string startHour { get; set; }
		public string endHour { get; set; }
		public location location { get; set; }
		public int maxSubscriptions { get; set; }
		public int openSubscriptions { get; set; }
		public int price { get; set; }
		public string description { get; set; }
		public string name { get; set; }
		public bool hasOpenSpots { get { return openSubscriptions > 0 ? true : false; } }

	}
}
