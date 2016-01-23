using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NinaSubscriptions.Master_Pages;
using NinaSubscriptions.BO;
using NinaSubscriptions.BLL;

namespace NinaSubscriptions.Pages.Public {

	public partial class bekijkAanbod:System.Web.UI.Page {

		protected void Page_Load(object sender,EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;

			// set page title
			master.setHeaderTitle("Bekijk aanbod");

			// load courses
			crud crud = new crud();

			List<course> allCourses = crud.getAllCourses();
			lstvCourses.DataSource = allCourses;
			lstvCourses.DataBind();
		}

		protected void lstvCourses_ItemCommand(object sender, ListViewCommandEventArgs e) {
			if (string.Equals(e.CommandName, "subscribeToCourse")) {
				Response.Redirect("subscribeToCourse.aspx?courseID=" + e.CommandArgument.ToString());
			}
		}
	}
}