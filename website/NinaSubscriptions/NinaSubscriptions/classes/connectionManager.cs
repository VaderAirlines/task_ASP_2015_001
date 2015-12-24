using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NinaSubscriptions {

    public static class connectionManager {
        
        public static SqlConnection getConnection() {
            return new SqlConnection(ConfigurationManager.AppSettings["connection"]);
        }

    }

}