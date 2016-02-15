using NinaSubscriptions.BLL;
using NinaSubscriptions.BO;
using NinaSubscriptions.Master_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
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
			crud crud = new crud();

			course course = new course() {
				name = txtNewName.Text,
				description = txtNewDescription.Text,
				courseType = crud.selectCourseType(Convert.ToInt32(ddNewCourseType.SelectedValue)),
				location = crud.selectLocation(Convert.ToInt32(ddNewLocation.SelectedValue)),
				startDate = Convert.ToDateTime(txtNewStartDate.Text),
				endDateInclusive = Convert.ToDateTime(txtNewEndDateInclusive.Text),
				startHour = Convert.ToInt32(txtNewStartHour.Text),
				endHour = Convert.ToInt32(txtNewEndHour.Text),
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

	}
}