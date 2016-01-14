using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Master_Pages {

	public partial class NinaSubscriptionsMaster:System.Web.UI.MasterPage {

		// private fields

		// internal methods --------------------------------------------------------------------
		internal void setHeaderTitle(string value) { 
			this.lblBannerTitle.Text = value;
		}

		internal void setLoggedInUser(int value) {
			throw new NotImplementedException();
		}
	}
}