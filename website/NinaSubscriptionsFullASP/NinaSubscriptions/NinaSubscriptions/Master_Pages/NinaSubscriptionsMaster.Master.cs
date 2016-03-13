using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinaSubscriptions.BO;
using NinaSubscriptions.BLL;
using PNV_Cryptor;

namespace NinaSubscriptions.Master_Pages {

	public partial class NinaSubscriptionsMaster : System.Web.UI.MasterPage {

		// privates
		private userProfile loggedInUser = null;

		// initializers
		protected void Page_Load(object sender, EventArgs e) {
			hfMessage.Value = "";

			loggedInUser = getLoggedInUserProfile();
			setLoggedInUserTitle();


			if (!IsPostBack) {
				setLoginUI();
				setUserNavigation();
				setAdminNavigation();
				txtUsername.Text = "dennis";
				txtPassword.Text = "dennis";
			}
		}

		// internal methods --------------------------------------------------------------------
		internal void setHeaderTitle(string value) {
			this.lblBannerTitle.Text = value;
		}

		internal bool login(string username, string password) {
			string encryptedPassword = new PNV_Cryptor.PNV_Cryptor("forgirlswholoveskateboarding", PNV_Cryptor.PNV_Cryptor.EncryptionMethods.TripleDes).EncryptData(password);
			int id = new crud().getIdForCredentials(username, encryptedPassword);

			if (id > 0) {
				Session["userID"] = id;
				return true;
			};

			return false;
		}

		internal userProfile getLoggedInUserProfile() {
			if (Session["userID"] == null) {
				return null;
			} else {
				if (loggedInUser == null) {
					setLoggedInUserProfile(Convert.ToInt32(Session["userID"]));
				};
			};

			return loggedInUser;
		}

		internal void setLoggedInUserProfile(int id) {
			try {
				loggedInUser = new crud().selectUserProfile(id);
			} catch (requestedDataNotFoundException ex) {
				loggedInUser = null;
			};
		}

		internal void setUIatLogin() {
			getLoggedInUserProfile();
			setLoggedInUserTitle();
			setLoginUI();
			setUserNavigation();
			setAdminNavigation();
		}

		internal void setMessage(messageClasses cssClass, string message) {
			hfMessage.Value = cssClass.ToString() + "|" + message;
		}

		// UI handlers
		protected void lnkBannerLogin_Click(object sender, EventArgs e) {
			if (login(txtUsername.Text, txtPassword.Text)) {
				setUIatLogin();
			} else {
				divLoggedInUser.InnerHtml = "Gebruikersnaam of paswoord incorrect.";
				txtUsername.Focus();
			}
		}

		protected void lnkBannerLogout_Click(object sender, EventArgs e) {
			Session["userID"] = null;
			loggedInUser = null;
			setLoginUI();
			setUserNavigation();
			setAdminNavigation();

			Response.Redirect("~/Pages/Public/bekijkAanbod.aspx");
		}

		// private helpers
		private void setLoggedInUserTitle() {
			divLoggedInUser.InnerHtml = loggedInUser == null ? "" : loggedInUser.firstName + " " + loggedInUser.name;
		}

		private void setLoginUI() {
			txtUsername.Text = "";
			txtPassword.Text = "";

			if (loggedInUser != null) {
				divLoginControls.Visible = false;
				divLogoutControls.Visible = true;
			} else {
				divLoginControls.Visible = true;
				divLogoutControls.Visible = false;
				divLoggedInUser.InnerHtml = "";
			};
		}

		private void setUserNavigation() {
			bool showAdminSection = loggedInUser == null ? false : true;

			liMijngegevens.Visible = showAdminSection;
		}

		private void setAdminNavigation() {
			bool showAdminSection = loggedInUser == null ? false : loggedInUser.isAdmin == true ? true : false;

			liBeheerCursussen.Visible = showAdminSection;
			liBekijkInschrijvingen.Visible = showAdminSection;
		}
	}

	public enum messageClasses {
		messageError,
		messageSuccess
	}

}