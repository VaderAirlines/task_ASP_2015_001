using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinaSubscriptions.Master_Pages;

namespace NinaSubscriptions.Pages.Public {

	public partial class loginOrRegister : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void btnLogin_Click(object sender, EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;

			if (master.login(txtUsername.Text, txtPassword.Text)) {
				master.setUIatLogin();

				string redirectUrl = "bekijkAanbod.aspx";
				if (Session["urlBeforeLogin"] != null) { redirectUrl = Session["urlBeforeLogin"].ToString(); };

				Response.Redirect(redirectUrl);

			} else {
				lblErrorMessage.Text = "Gebruikersnaam of paswoord is onjuist.";
				txtUsername.Focus();
			};
		}

		protected void btnRegister_Click(object sender, EventArgs e) {
			Response.Redirect("register.aspx?username=" + HttpUtility.UrlEncode(txtUsername.Text));
		}
	}
}