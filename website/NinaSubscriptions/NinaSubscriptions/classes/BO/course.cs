using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinaSubscriptions {

	public class course {
		public int id { get; set; }
		public string datumVan { get; set; }
		public string datumTot { get; set; }
		public int startuur { get; set; }
		public int einduur { get; set; }
		public int maxDeelnemers { get; set; }
		public int kostprijs { get; set; }
		public string naam { get; set; }
		public string omschrijving { get; set; }
		public int leeftijdVanaf { get; set; }
		public int leeftijdTotEnMet { get; set; }
		public string fotoLink { get; set; }
		public string locatieNaam { get; set; }
		public string locatieAdres { get; set; }
	}

}