using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinaSubscriptions.Master_Pages;
using NinaSubscriptions.Custom_validation;
using System.Text;

namespace NinaSubscriptions.Pages.Public {

	public partial class loginOrRegister : System.Web.UI.Page {

		// initializers
		protected void Page_Load(object sender, EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;

			// set page title
			master.setHeaderTitle("Log in of registreer");
		}

		// UI handlers
		protected void btnLogin_Click(object sender, EventArgs e) {
			customValidator validator = new customValidator();
			validator.addValidationRule(new customValidationRule(txtUsername, validator.required, null, "Gelieve een gebruikersnaam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtUsername, validator.maxLength, "50", "Gebruikersnaam mag niet langer zijn dan 50 karakters"));
			validator.addValidationRule(new customValidationRule(txtPassword, validator.required, null, "Gelieve een wachtwoord in te vullen"));
			validator.addValidationRule(new customValidationRule(txtPassword, validator.maxLength, "50", "Wachtwoord mag niet langer zijn dan 50 karakters"));

			List<string> errors = validator.validate();
			StringBuilder messageText = new StringBuilder();
			if (errors.Count > 0) {				
				foreach (string error in errors) {
					messageText.Append(error + "<br>");
				}

				((NinaSubscriptionsMaster)this.Master).setMessage(messageClasses.messageError, messageText.ToString());

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
				//lblErrorMessage.Text = "Gebruikersnaam of paswoord is onjuist.";
				((NinaSubscriptionsMaster) this.Master).setMessage(messageClasses.messageError, "Gebruikersnaam of paswoord is onjuist.");
				txtUsername.Focus();
			};
		}

		protected void btnRegister_Click(object sender, EventArgs e) {
			Response.Redirect("register.aspx?username=" + HttpUtility.UrlEncode(txtUsername.Text));
		}
	}
}