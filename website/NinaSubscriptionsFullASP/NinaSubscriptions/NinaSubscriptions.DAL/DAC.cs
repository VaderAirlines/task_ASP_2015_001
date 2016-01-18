using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NinaSubscriptions.DAL {
	public static class DAC {

		// fields
		static SqlDataAdapter adapter = new SqlDataAdapter();

		// methods
		public static DataTable execute(spBase spSubject,spCommand spCommand,Dictionary<string,string> spParameters = null) {
			using(SqlConnection con = connectionManager.getConnection()) {
				SqlCommand command = new SqlCommand(spSubject.ToString() + "_" + spCommand.ToString(),con);
				command.CommandType = CommandType.StoredProcedure;

				if(spParameters != null) { setParameters(command,spParameters); };

				DataTable retTable = new DataTable();

				try {
					SqlParameter returnValue = null;
					if (con.State == ConnectionState.Closed) { con.Open(); };

					switch(spCommand.ToString()) {
						case "insert":
							returnValue = getOutputParameter();
							command.Parameters.Add(returnValue);
							adapter.InsertCommand = command;
							adapter.InsertCommand.ExecuteNonQuery();
							fillReturnTable(retTable,(int)returnValue.Value);
							break;
						case "update":
							returnValue = getOutputParameter();
							command.Parameters.Add(returnValue);
							adapter.UpdateCommand = command;
							adapter.UpdateCommand.ExecuteNonQuery();
							fillReturnTable(retTable,(int)returnValue.Value);
							break;
						case "delete":
							returnValue = getOutputParameter();
							command.Parameters.Add(returnValue);
							adapter.DeleteCommand = command;
							adapter.DeleteCommand.ExecuteNonQuery();
							fillReturnTable(retTable,(int)returnValue.Value);
							break;
						// all select statements can use the default function
						default:
							adapter.SelectCommand = command;
							adapter.Fill(retTable);
							break;
					}

				} catch {
					throw;
				}

				return retTable;
				
			}
		}

		// private helpers
		private static void setParameters(SqlCommand command,Dictionary<string,string> spParameters) {
			foreach(KeyValuePair<string,string> parameter in spParameters) {
				command.Parameters.AddWithValue("@" + parameter.Key,parameter.Value);
			}
		}

		private static SqlParameter getOutputParameter() {
			SqlParameter param = new SqlParameter("@returnValue",SqlDbType.Int);
			param.Direction = ParameterDirection.ReturnValue;

			return param;
		}

		private static void fillReturnTable(DataTable retTable,int id) {
			retTable.Columns.Add("id");
			DataRow newRow = retTable.NewRow();
			newRow["id"] = id;
			retTable.Rows.Add(newRow);
		}

	}

	public enum spBase {
		course,
		courseType,
		location,
		subscription,
		userProfile,
		child
	}

	public enum spCommand {
		insert,
		select,
		update,
		delete,
		selectAll,
		selectAllForUserProfile,
		selectAllForCourse
	}

}
