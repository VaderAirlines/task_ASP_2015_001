using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Master_pages {
	public partial class ninaSubscriptions:System.Web.UI.MasterPage {
		protected void Page_Load(object sender,EventArgs e) {
			//TODO: remove -> only for debugging
			txtOutputter.Visible = false;

			if(Session["userID"] != null) {
				txtOutputter.Text = "logged in with userID: " + Session["userID"];
			} else {
				txtOutputter.Text = "not logged in";
			};
		}
	}
}