using NinaSubscriptions.BLL;
using NinaSubscriptions.BO;
using NinaSubscriptions.Master_Pages;
using NinaSubscriptions.SettingsHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Pages.Public {

	public partial class mijnGegevens:System.Web.UI.Page {

		// initializers
		protected void Page_Load(object sender,EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
			master.setHeaderTitle(settingsHelper.get("title_mijn_gegevens"));

			userProfile user = master.getLoggedInUserProfile();
			if (user == null) { Response.Redirect("~/Pages/Public/bekijkAanbod.aspx"); };

			fillPersonalData(user);

			crud crud = new crud();
			
			lstvChildren.DataSource = crud.getAllChildrenForUserProfile(user.id);
			lstvChildren.DataBind();

			lstvSubscriptions.DataSource = crud.getAllSubscriptionsForUserProfile(user.id);
			lstvSubscriptions.DataBind();			
		}


		// helpers
		private void fillPersonalData(userProfile user) {
			lblUsername.Text = user.userName;
			lblName.Text = user.name;
			lblFirstname.Text = user.firstName;
			lblEmailAddress.Text = user.emailAddress;
			lblNumber.Text = user.number.ToString();
			lblPhone.Text = user.phone;
			lblPlace.Text = user.place;
			lblPostalCode.Text = user.postalCode.ToString();
			lblStreet.Text = user.street;
		}

	}
}