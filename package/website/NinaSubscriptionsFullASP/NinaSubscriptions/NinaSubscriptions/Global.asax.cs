using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace NinaSubscriptions {
	public class Global : System.Web.HttpApplication {

		protected void Application_Error(object sender, EventArgs e) {
			Server.ClearError();
			Server.Transfer("Pages/Error/error.aspx");
		}

	}
}