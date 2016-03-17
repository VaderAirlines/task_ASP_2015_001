using NinaSubscriptions.Master_Pages;
using NinaSubscriptions.SettingsHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Pages.Error {

	public partial class error : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
			master.setHeaderTitle(settingsHelper.get("title_error"));
		}
	}

}