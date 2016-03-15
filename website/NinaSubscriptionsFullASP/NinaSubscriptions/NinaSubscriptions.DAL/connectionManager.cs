using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PNV_Cryptor;

namespace NinaSubscriptions.DAL {

	public static class connectionManager {

		public static SqlConnection getConnection() {
			try {
				return new SqlConnection(new PNV_Cryptor.PNV_Cryptor(
					"fghls",
					PNV_Cryptor.PNV_Cryptor.EncryptionMethods.TripleDes)
					.DecryptData(Properties.Settings.Default.connectionString));
			} catch {
				throw new ArgumentException("Kon de connectiestring niet ontrafelen.");
			}
		}

	}
}
