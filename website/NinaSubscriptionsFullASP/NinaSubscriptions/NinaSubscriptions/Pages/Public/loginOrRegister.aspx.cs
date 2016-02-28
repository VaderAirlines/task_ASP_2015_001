using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinaSubscriptions.Master_Pages;
using NinaSubscriptions.Custom_validation;

namespace NinaSubscriptions.Pages.Public {

	public partial class loginOrRegister : System.Web.UI.Page {

		protected void btnLogin_Click(object sender, EventArgs e) {
			// validate fields before continuing
			lblErrorMessage.Text = string.Empty;

			customValidator validator = new customValidator();
			validator.addValidationRule(new customValidationRule(txtUsername, validator.required, null, "Gelieve een gebruikersnaam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtUsername, validator.maxLength, "50", "Gebruikersnaam mag niet langer zijn dan 50 karakters"));
			validator.addValidationRule(new customValidationRule(txtPassword, validator.required, null, "Gelieve een wachtwoord in te vullen"));
			validator.addValidationRule(new customValidationRule(txtPassword, validator.maxLength, "50", "Wachtwoord mag niet langer zijn dan 50 karakters"));
			List<string> errors = validator.validate();
			if (errors.Count > 0) {
				foreach (string error in errors) {
					lblErrorMessage.Text += error + "<br>";
				}
				return;
			}

			// if all is validated, continue...
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