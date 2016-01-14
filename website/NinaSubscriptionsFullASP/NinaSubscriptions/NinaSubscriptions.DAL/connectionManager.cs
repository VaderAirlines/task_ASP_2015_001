using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NinaSubscriptions.DAL {

	public static class connectionManager {

		public static SqlConnection getConnection() {
			return new SqlConnection(Properties.Settings.Default.connectionString);
		}

	}
}
