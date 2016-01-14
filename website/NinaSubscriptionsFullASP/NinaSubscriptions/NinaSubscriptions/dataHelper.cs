using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NinaSubscriptions {

	public static class dataHelper {

		public static int getIdFromDataTable(DataTable table) {
			try {
				return Convert.ToInt32(table.Rows[0]["id"]);
			} catch {
				return -1;
			}
		}
	}
}