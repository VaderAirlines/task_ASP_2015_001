using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;

namespace NinaSubscriptions.webservices {

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class loginService:System.Web.Services.WebService {

        [WebMethod(EnableSession = true)]
        public bool getLoginStatus(string username, string password) {
            using (SqlConnection con = connectionManager.getConnection()) {
                using (SqlCommand com = new SqlCommand("checkLogin", con)) {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("login", username);
                    com.Parameters.AddWithValue("password", password);

                    con.Open();

                    int userID = Convert.ToInt32(com.ExecuteScalar());

                    if (userID > 0) {
                        HttpContext.Current.Session["userID"] = userID;
                        return true; 
                    };

					HttpContext.Current.Session["userID"] = null;
                    return false;
                }
            }
        }
    }
}
