using System;
using System.Collections.Generic;
using System.Text;

namespace NinaSubscriptions.BO {

	public class userProfile {

		// properties
		public int id { get; set; }
		public string name { get; set; }
		public string firstName { get; set; }
		public string street { get; set; }
		public int number { get; set; }
		public int postalCode { get; set; }
		public string place { get; set; }
		public string phone { get; set; }
		public string emailAddress { get; set; }
		public string userName { get; set; }
		public string passwordHash { get; set; }
		public List<child> children { get; set; }
		public Boolean isAdmin { get; set; }

	}
}
