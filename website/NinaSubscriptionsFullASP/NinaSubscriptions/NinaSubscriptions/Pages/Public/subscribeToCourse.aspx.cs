using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Pages.Public {

	public partial class subscribeToCourse : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {
			lblTest.Text += Request.QueryString["courseID"];
		}
	}
}