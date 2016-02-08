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

	public partial class beheerCursussen:System.Web.UI.Page {

		// fields
		List<location> locations = new List<location>();
		List<courseType> courseTypes = new List<courseType>();

		// initializers
		protected void Page_Load(object sender,EventArgs e) {
			crud crud = new crud();
			locations = crud.getAllLocations();
			courseTypes = crud.getAllCourseTypes();

			if (!IsPostBack) {
				NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;

				// set page title
				master.setHeaderTitle("Beheer cursussen");

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

		// helpers
		private void fillCoursesList(crud crud) {
			if (crud == null) { crud = new crud(); };

			List<course> allCourses = crud.getAllCourses();
			lstvCourses.DataSource = allCourses;
			lstvCourses.DataBind();
		}

	}
}