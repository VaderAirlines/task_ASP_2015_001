using NinaSubscriptions.BLL;
using NinaSubscriptions.BO;
using NinaSubscriptions.Master_Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinaSubscriptions.Pages.Admin {

	public partial class bekijkInschrijvingen : System.Web.UI.Page {

		// initializers
		protected void Page_Load(object sender, EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
			master.setHeaderTitle("Bekijk inschrijvingen");

			userProfile user = master.getLoggedInUserProfile();
			if (user == null || user.isAdmin == false) { Response.Redirect("~/Pages/Public/bekijkAanbod.aspx"); };

			if (!IsPostBack) {
				crud crud = new crud();

				// fill course dropdown
				List<course> allCourses = crud.getAllCourses();
				course emptyCourse = new course() { id = 0 };
				allCourses.Insert(0, emptyCourse);
				ddCourseNames.DataSource = allCourses;
				ddCourseNames.DataTextField = "name";
				ddCourseNames.DataValueField = "id";
				ddCourseNames.DataBind();

				List<userProfile> allUserProfiles = crud.getAllUserProfiles();
				userProfile emptyProfile = new userProfile() { id = 0 };
				allUserProfiles.Insert(0, emptyProfile);
				ddUserProfiles.DataSource = allUserProfiles;
				ddUserProfiles.DataTextField = "fullname";
				ddUserProfiles.DataValueField = "id";
				ddUserProfiles.DataBind();

				cldrDates.SelectedDate = DateTime.Now;
			}
		}

		// UI handlers
		protected void ddCourseNames_SelectedIndexChanged(object sender, EventArgs e) {
			int courseID = Convert.ToInt32(ddCourseNames.SelectedValue);

			crud crud = new crud();
			List<subscription> subscriptions = crud.getAllSubscriptionsForCourse(courseID);
			DataTable table = getFilledSubscriptionTable(subscriptions);

			grdResults.DataSource = table;
			grdResults.DataBind();

			resultsFor.InnerText = ddCourseNames.SelectedItem.Text;
		}

		protected void ddUserProfiles_SelectedIndexChanged(object sender, EventArgs e) {
			int userProfileID = Convert.ToInt32(ddUserProfiles.SelectedValue);

			crud crud = new crud();
			List<subscription> subscriptions = crud.getAllSubscriptionsForUserProfile(userProfileID);
			DataTable table = getFilledSubscriptionTable(subscriptions);

			grdResults.DataSource = table;
			grdResults.DataBind();

			resultsFor.InnerText = ddUserProfiles.SelectedItem.Text;
		}

		protected void cldrDates_SelectionChanged(object sender, EventArgs e) {
			DateTime selectedDate = cldrDates.SelectedDate;

			crud crud = new crud();
			List<subscription> subscriptions = crud.getAllSubscriptionsForCoursesOnDate(selectedDate);
			DataTable table = getFilledSubscriptionTable(subscriptions);

			grdResults.DataSource = table;
			grdResults.DataBind();

			resultsFor.InnerText = selectedDate.ToShortDateString();

			//grdResults.DataSource = crud.getCoursesWithNrOfSubscriptionsOnDate(selectedDate);
			//grdResults.DataBind();
		}


		// helpers
		private DataTable getSubscriptionBaseTable() {
			DataTable retTable = new DataTable();
			retTable.Columns.Add("id");
			retTable.Columns.Add("cursusNaam");
			retTable.Columns.Add("kindAchternaam");
			retTable.Columns.Add("kindVoornaam");
			retTable.Columns.Add("heeftBetaald");

			return retTable;
		}

		private DataTable getFilledSubscriptionTable(List<subscription> subscriptions) {
			DataTable table = getSubscriptionBaseTable();

			foreach (subscription subscription in subscriptions) {
				DataRow row = table.NewRow();

				row["id"] = subscription.id;
				row["cursusNaam"] = subscription.course.name;
				row["kindAchternaam"] = subscription.child.name;
				row["kindVoornaam"] = subscription.child.firstName;
				row["heeftBetaald"] = subscription.paymentConfirmed;

				table.Rows.Add(row);
			}

			return table;
		}

	}
}