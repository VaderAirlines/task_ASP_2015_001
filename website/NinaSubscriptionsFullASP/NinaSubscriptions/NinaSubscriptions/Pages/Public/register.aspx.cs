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

namespace NinaSubscriptions.Pages.Public {
	public partial class register : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			String username = Request.QueryString["username"] ?? "";
		}

		protected void btnRegister_Click(object sender, EventArgs e) {
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
				clearUI();

				NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
				if (master.login(txtUsername.Text, txtPassword.Text)) { master.setUIatLogin(); };

				string redirectUrl = "bekijkAanbod.aspx";
				if (Session["urlBeforeLogin"] != null) { redirectUrl = Session["urlBeforeLogin"].ToString(); };

				HyperLink redirect = new HyperLink();
				redirect.NavigateUrl = redirectUrl;
				redirect.Text = "U heeft zich succesvol geregistreerd. Klik hier om terugkeren naar de vorige pagina.";
				successMessage.Controls.Add(redirect);

			} else {
				lblErrorMessage.Text = "Gelieve alle velden correct in te vullen.";
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