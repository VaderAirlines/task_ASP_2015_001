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

        [WebMethod]
        public bool getLoginStatus(string username, string password) {
            using (SqlConnection con = connectionManager.getConnection()) {
                throw new NotImplementedException();
            }
        }
    }
}
