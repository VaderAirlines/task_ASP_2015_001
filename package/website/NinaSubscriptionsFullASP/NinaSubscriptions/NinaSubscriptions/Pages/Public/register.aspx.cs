using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinaSubscriptions.BO;
using NinaSubscriptions.BLL;
using System.Timers;
using NinaSubscriptions.Master_Pages;
using NinaSubscriptions.Custom_validation;
using System.Text;
using NinaSubscriptions.SettingsHelper;

namespace NinaSubscriptions.Pages.Public {
	public partial class register : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;

			// set page title
			master.setHeaderTitle(settingsHelper.get("title_register"));

			String username = Request.QueryString["username"] ?? "";
		}

		protected void btnRegister_Click(object sender, EventArgs e) {
			customValidator validator = new customValidator();
			validator.addValidationRule(new customValidationRule(txtUsername, validator.required, null, "Gelieve een gebruikersnaam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtName, validator.required, null, "Gelieve een naam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtFirstName, validator.required, null, "Gelieve een voornaam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtEmailAddress, validator.required, null, "Gelieve een emailadres in te vullen"));
			validator.addValidationRule(new customValidationRule(txtEmailAddress, validator.email, null, "Gelieve een geldig emailadres in te vullen"));
			validator.addValidationRule(new customValidationRule(txtPhone, validator.required, null, "Gelieve een telefoonnummer in te vullen"));
			validator.addValidationRule(new customValidationRule(txtStreet, validator.required, null, "Gelieve een straat in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNumber, validator.required, null, "Gelieve een huisnummer in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNumber, validator.numeric, null, "Gelieve een geheel getal in te vullen"));
			validator.addValidationRule(new customValidationRule(txtPostalCode, validator.required, null, "Gelieve een postcode in te vullen"));
			validator.addValidationRule(new customValidationRule(txtPlace, validator.required, null, "Gelieve een plaats in te vullen"));
			validator.addValidationRule(new customValidationRule(txtPassword, validator.required, null, "Gelieve een wachtwoord in te vullen"));
			validator.addValidationRule(new customValidationRule(txtPasswordRepeat, validator.required, null, "Gelieve een wachtwoord in te vullen"));

			List<string> errors = validator.validate();
			StringBuilder messageText = new StringBuilder();
			if (errors.Count > 0) {
				foreach (string error in errors) {
					messageText.Append(error + "<br>");
				}

				((NinaSubscriptionsMaster) this.Master).setMessage(messageClasses.messageError, messageText.ToString());

				return;
			}

			if (txtPassword.Text != txtPasswordRepeat.Text) {
				((NinaSubscriptionsMaster) this.Master).setMessage(messageClasses.messageError, "De ingegeven wachtwoorden komen niet overeen.");
				return;
			}

			// if all is validated, continue...
			crud crud = new crud();

			userProfile profile = new userProfile();
			profile.userName = txtUsername.Text;
			profile.passwordHash = new PNV_Cryptor.PNV_Cryptor("forgirlswholoveskateboarding", PNV_Cryptor.PNV_Cryptor.EncryptionMethods.TripleDes).EncryptData(txtPassword.Text);
			profile.name = txtName.Text;
			profile.firstName = txtFirstName.Text;
			profile.emailAddress = txtEmailAddress.Text;
			profile.phone = txtPhone.Text;
			profile.street = txtStreet.Text;
			profile.number = Convert.ToInt32(txtNumber.Text);
			profile.postalCode = Convert.ToInt32(txtPostalCode.Text);
			profile.place = txtPlace.Text;
			profile.isAdmin = false;

			if (crud.insertUserProfile(profile) > 0) {
				NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
				if (master.login(txtUsername.Text, txtPassword.Text)) { 
					master.setUIatLogin(); 
				};

				string redirectUrl = "bekijkAanbod.aspx";
				if (Session["urlBeforeLogin"] != null) { redirectUrl = Session["urlBeforeLogin"].ToString(); };

				string redirect = "<a href=\"" + redirectUrl + "\">U heeft zich succesvol geregistreerd. Klik hier om terugkeren naar de vorige pagina.</a>";
				master.setMessage(messageClasses.messageSuccess, redirect);

				clearUI();

			} else {
				NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
				master.setMessage(messageClasses.messageError, "Gelieve alle velden correct in te vullen.");
			};
		}

		private void clearUI() {
			foreach (Control control in componentWrapper.Controls) {
				if (control.GetType() == typeof(TextBox)) {
					TextBox textbox = (TextBox) control;
					textbox.Text = ""; 
				}
			}
		}
	}
}