using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinaSubscriptions.SettingsHelper {
	
	public static class settingsHelper {
		
		public static string get(string key) {
			return Properties.Settings.Default[key].ToString();
		}

	}
}