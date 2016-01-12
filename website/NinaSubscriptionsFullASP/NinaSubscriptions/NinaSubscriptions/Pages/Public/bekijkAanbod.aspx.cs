using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Pages.Public {

	public partial class bekijkAanbod:System.Web.UI.Page {

		protected void Page_Load(object sender,EventArgs e) {
			Label bannerTitle = Master.FindControl("lblBannerTitle") as Label;
            bannerTitle.Text = "Hello";
		}
	}
}