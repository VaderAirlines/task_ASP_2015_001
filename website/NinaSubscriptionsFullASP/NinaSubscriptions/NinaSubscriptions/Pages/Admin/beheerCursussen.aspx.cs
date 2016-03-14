using NinaSubscriptions.BLL;
using NinaSubscriptions.BO;
using NinaSubscriptions.Custom_validation;
using NinaSubscriptions.Master_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Pages.Admin {

	public partial class beheerCursussen : System.Web.UI.Page {

		// fields
		List<location> locations = new List<location>();
		List<courseType> courseTypes = new List<courseType>();

		// initializers
		protected void Page_Load(object sender, EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
			master.setHeaderTitle("Beheer cursussen");

			userProfile user = master.getLoggedInUserProfile();
			if (user == null || user.isAdmin == false) { Response.Redirect("~/Pages/Public/bekijkAanbod.aspx"); };

			crud crud = new crud();
			locations = crud.getAllLocations();
			courseTypes = crud.getAllCourseTypes();

			if (!IsPostBack) {
				// load courses
				fillCoursesList(crud);
			};
		}

		protected void ddLocation_Init(object sender, EventArgs e) {
			DropDownList dropdown = (DropDownList) sender;

			dropdown.DataSource = locations;
			dropdown.DataTextField = "name";
			dropdown.DataValueField = "id";
			dropdown.DataBind();
		}

		protected void ddCourseType_Load(object sender, EventArgs e) {
			DropDownList dropdown = (DropDownList) sender;

			dropdown.DataSource = courseTypes;
			dropdown.DataTextField = "referrer";
			dropdown.DataValueField = "id";
			dropdown.DataBind();
		}

		protected void btnSaveNewCourse_Click(object sender, EventArgs e) {
			customValidator validator = new customValidator();
			validator.addValidationRule(new customValidationRule(txtNewName, validator.required, null, "Gelieve een naam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewDescription, validator.required, null, "Gelieve een omschrijving in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewStartDate, validator.required, null, "Gelieve een startdatum in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewStartDate, validator.validDate, null, "Gelieve een geldige startdatum in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewEndDateInclusive, validator.required, null, "Gelieve een einddatum in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewEndDateInclusive, validator.validDate, null, "Gelieve een geldige einddatum in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewStartHour, validator.required, null, "Gelieve een startuur in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewStartHour, validator.hour, null, "Gelieve een geldig startuur in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewEndHour, validator.required, null, "Gelieve een einduur in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewEndHour, validator.hour, null, "Gelieve een geldig einduur in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewMaxSubscriptions, validator.required, null, "Gelieve het maximum aantal inschrijvingen in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewMaxSubscriptions, validator.numeric, null, "Gelieve het maximum aantal inschrijvingen in te vullen als geheel getal"));
			validator.addValidationRule(new customValidationRule(txtNewPrice, validator.required, null, "Gelieve een prijs in te vullen"));
			validator.addValidationRule(new customValidationRule(txtNewPrice, validator.numeric, null, "Gelieve een prijs in te vullen als geheel getal"));

			List<string> errors = validator.validate();
			StringBuilder messageText = new StringBuilder();
			if (errors.Count > 0) {
				foreach (string error in errors) {
					messageText.Append(error + "<br>");
				}

				((NinaSubscriptionsMaster) this.Master).setMessage(messageClasses.messageError, messageText.ToString());

				return;
			}

			crud crud = new crud();

			course course = new course() {
				name = txtNewName.Text,
				description = txtNewDescription.Text,
				courseType = crud.selectCourseType(Convert.ToInt32(ddNewCourseType.SelectedValue)),
				location = crud.selectLocation(Convert.ToInt32(ddNewLocation.SelectedValue)),
				startDate = Convert.ToDateTime(txtNewStartDate.Text),
				endDateInclusive = Convert.ToDateTime(txtNewEndDateInclusive.Text),
				startHour = txtNewStartHour.Text,
				endHour = txtNewEndHour.Text,
				maxSubscriptions = Convert.ToInt32(txtNewMaxSubscriptions.Text),
				price = Convert.ToInt32(txtNewPrice.Text)
			};

			crud.insertCourse(course);

			clearNewCourseForm();
			fillCoursesList(crud);
		}

		// helpers
		private void fillCoursesList(crud crud) {
			if (crud == null) { crud = new crud(); };

			List<course> allCourses = crud.getAllCourses();
			lstvCourses.DataSource = allCourses;
			lstvCourses.DataBind();
		}

		private void clearNewCourseForm() {
			txtNewName.Text = "";
			txtNewDescription.Text = "";
			ddNewCourseType.SelectedIndex = -1;
			ddNewLocation.SelectedIndex = -1;
			txtNewStartDate.Text = "";
			txtNewEndDateInclusive.Text = "";
			txtNewStartHour.Text = "";
			txtNewEndHour.Text = "";
			txtNewMaxSubscriptions.Text = "";
			txtNewPrice.Text = "";
		}

		protected void lstvCourses_ItemCommand(object sender, ListViewCommandEventArgs e) {
			if (string.Equals(e.CommandName, "removeCourse")) {
				crud crud = new crud();
				crud.deleteCourse(Convert.ToInt32(e.CommandArgument));

				clearNewCourseForm();
				fillCoursesList(crud);
			}
		}

	}
}