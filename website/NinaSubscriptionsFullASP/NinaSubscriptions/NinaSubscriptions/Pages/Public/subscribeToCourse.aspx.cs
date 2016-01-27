using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinaSubscriptions.BO;
using NinaSubscriptions.BLL;
using NinaSubscriptions.Master_Pages;

namespace NinaSubscriptions.Pages.Public {

	public partial class subscribeToCourse : System.Web.UI.Page {

		// initializers
		protected void Page_Load(object sender, EventArgs e) {
			int courseID = Convert.ToInt32(Request.QueryString["courseID"]);

			crud crud = new crud();
			course course = crud.selectCourse(courseID);
			fillCourseData(course);

			if (!IsPostBack) { refreshLists(); };
		}

		// UI handlers
		protected void lstSubscribedChildren_ItemCommand(object sender, ListViewCommandEventArgs e) {
			if (string.Equals(e.CommandName, "removeChild")) {
				List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();
				subscribedChildren.Remove(subscribedChildren.Find(x => x.id == Convert.ToInt32(e.CommandArgument.ToString())));

				refreshLists();
			}
		}

		protected void btnAddExistingChild_Click(object sender, EventArgs e) {
			List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();
			List<int> selectedChildIndices = lstAllChildren.GetSelectedIndices().ToList();
			
			selectedChildIndices.ForEach(childIndex => subscribedChildren.Add(new crud().selectChild(Convert.ToInt32(lstAllChildren.Items[childIndex].Value))));			
			Session["subscribedChildren"] = subscribedChildren;

			refreshLists();
		}

		protected void btnAddNewChild_Click(object sender, EventArgs e) {
			List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();
			
			child newChild = new child();
			newChild.name = txtName.Text;
			newChild.firstName = txtFirstName.Text;
			newChild.dateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
			newChild.id = generateTemporaryChildID(subscribedChildren.Select(child => child.id).ToList());

			subscribedChildren.Add(newChild);

			refreshLists();
			clearNewChildUI();
		}

		// HELPERS
		private void fillCourseData(course course) {
			lblName.Text = course.name;
			lblDescription.Text = course.description;
			lblAgeFrom.Text = course.courseType.ageFrom.ToString();
			lblAgeTo.Text = course.courseType.ageToInclusive.ToString();
			lblDateFrom.Text = course.startDate.ToString("dd MMMM yyyy");
			lblDateTo.Text = course.endDateInclusive.ToString("dd MMMM yyyy");
			lblLocationName.Text = course.location.name;
			lblLocationAddress.Text = course.location.street + " " + course.location.number + ", " +
									  course.location.postalCode + " " + course.location.place;
			lblSubscriptionsLeft.Text = course.maxSubscriptions.ToString() + " plaatsen";
			lblPrice.Text = "€ " + course.price;
		}

		private void refreshLists() {
			List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();
			List<child> childrenForUserProfile = new crud().getAllChildrenForUserProfile(Convert.ToInt32(Session["userID"]));

			subscribedChildren.ForEach(sChild => childrenForUserProfile.Remove(childrenForUserProfile.Find(uChild => uChild.id == sChild.id)));

			// fill select box (all children for user profile)
			if (childrenForUserProfile.Count < 1) {
				divExistingChildSelector.Visible = false;
			} else {
				divExistingChildSelector.Visible = true;
				lstAllChildren.Items.Clear();
				childrenForUserProfile.ForEach(uChild => lstAllChildren.Items.Add(new ListItem(uChild.firstName + " " + uChild.name, uChild.id.ToString())));
			};

			// fill list of children to subscribe
			lstSubscribedChildren.DataSource = subscribedChildren;
			lstSubscribedChildren.DataBind();
						
		}

		private int generateTemporaryChildID(List<int> ids) {
			Random r = new Random();
			while (true) {
				int newID = r.Next(int.MaxValue - 10000, int.MaxValue);
				if (!ids.Contains(newID)) { return newID; };
			}
		}

		private void clearNewChildUI() {
			foreach (Control control in divNewChildSelector.Controls) {
				if (control.GetType() == typeof(TextBox)) {
					TextBox textbox = control as TextBox;
					textbox.Text = "";
				}
			}
		}
	}
}