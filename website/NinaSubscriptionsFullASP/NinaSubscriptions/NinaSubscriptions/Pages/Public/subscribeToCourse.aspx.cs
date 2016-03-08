using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NinaSubscriptions.BO;
using NinaSubscriptions.BLL;
using NinaSubscriptions.Master_Pages;
using System.Drawing;
using NinaSubscriptions.Custom_validation;

namespace NinaSubscriptions.Pages.Public {

	public partial class subscribeToCourse : System.Web.UI.Page {

		// initializers
		protected void Page_Load(object sender, EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;
			master.setHeaderTitle("Inschrijven op een cursus");

			userProfile user = master.getLoggedInUserProfile();
			if (user == null) { Response.Redirect("~/Pages/Public/bekijkAanbod.aspx"); };

			int courseID = Convert.ToInt32(Request.QueryString["courseID"]);

			crud crud = new crud();
			course course = crud.selectCourse(courseID);
			fillCourseData(course);

			if (!IsPostBack) {
				Session.Remove("subscribedChildren");
				refreshLists(courseID);
			};
		}

		// UI handlers
		protected void lstSubscribedChildren_ItemCommand(object sender, ListViewCommandEventArgs e) {
			if (string.Equals(e.CommandName, "removeChild")) {
				List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();
				subscribedChildren.Remove(subscribedChildren.Find(x => x.id == Convert.ToInt32(e.CommandArgument.ToString())));
				Session["subscribedChildren"] = subscribedChildren;
				
				refreshLists(Convert.ToInt32(Request.QueryString["courseID"]));
			}
		}

		protected void btnAddExistingChild_Click(object sender, EventArgs e) {
			List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();
			List<int> selectedChildIndices = lstAllChildren.GetSelectedIndices().ToList();
			List<child> childrenToAdd = new List<child>();

			int courseID = Convert.ToInt32(Request.QueryString["courseID"]);
			course course = new crud().selectCourse(courseID);

			selectedChildIndices.ForEach(childIndex => childrenToAdd.Add(new crud().selectChild(Convert.ToInt32(lstAllChildren.Items[childIndex].Value))));

			bool containsErroneousChild = false;
			foreach (child child in childrenToAdd) {
				if (childHasCorrectAge(child.dateOfBirth, course.courseType.ageFrom, course.courseType.ageToInclusive)) {
					subscribedChildren.Add(child);
				} else {
					containsErroneousChild = true;
				}
			}

			if (containsErroneousChild) {
				lblMessage.ForeColor = Color.Red;
				lblMessage.Text = "Enkel de kinderen met een toegelaten leeftijd werden toegevoegd.";
			}

			Session["subscribedChildren"] = subscribedChildren;

			refreshLists(courseID);
		}

		protected void btnAddNewChild_Click(object sender, EventArgs e) {
			// validate fields before continuing
			lblErrorMessage.Text = string.Empty;

			customValidator validator = new customValidator();
			validator.addValidationRule(new customValidationRule(txtName, validator.required, null, "Gelieve een naam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtFirstName, validator.required, null, "Gelieve een voornaam in te vullen"));
			validator.addValidationRule(new customValidationRule(txtDateOfBirth, validator.required, null, "Gelieve een geboortedatum in te vullen"));
			validator.addValidationRule(new customValidationRule(txtDateOfBirth, validator.validDate, null, "Gelieve een geldige datum in te vullen"));

			List<string> errors = validator.validate();
			if (errors.Count > 0) {
				foreach (string error in errors) {
					lblErrorMessage.Text += error + "<br>";
				}
				return;
			}

			// if all is validated, continue...
			List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();

			try {
				child newChild = new child();
				newChild.name = txtName.Text;
				newChild.firstName = txtFirstName.Text;
				newChild.dateOfBirth = CreateDate(txtDateOfBirth.Text);
				newChild.id = generateTemporaryChildID(subscribedChildren.Select(child => child.id).ToList());
				newChild.userProfileID = Convert.ToInt32(Session["userID"]);

				int courseID = Convert.ToInt32(Request.QueryString["courseID"]);
				course course = new crud().selectCourse(courseID);

				if (childHasCorrectAge(newChild.dateOfBirth, course.courseType.ageFrom, course.courseType.ageToInclusive)) {
					subscribedChildren.Add(newChild);
					Session["subscribedChildren"] = subscribedChildren;

					refreshLists(courseID);
					clearNewChildUI();
				} else {
					lblMessage.ForeColor = Color.Red;
					lblMessage.Text = "Het kind dat u wil toevoegen heeft niet de toegelaten leeftijd.";
				}

			} catch {
				lblMessage.ForeColor = Color.Red;
				lblMessage.Text = "Gelieve alle velden na te kijken en correct in te vullen.";
			}
		}

		protected void btnSaveSubscriptions_Click(object sender, EventArgs e) {
			crud crud = new crud();

			List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? new List<child>();

			int courseID = Convert.ToInt32(Request.QueryString["courseID"]);
			course course = crud.selectCourse(courseID);

			subscription subscription = new subscription();
			subscription.course = course;
			subscription.paymentConfirmed = false;

			subscribedChildren.ForEach(child => child.id = child.id >= int.MaxValue - 10000 ? crud.insertChild(child) : child.id);

			foreach (child child in subscribedChildren) {
				subscription.child = child;
				if (new crud().getSubscriptionOnCourseAndChild(course.id, child.id).Count < 1) {
					crud.insertSubscription(subscription);
				}
			};

			lblMessage.Text = "De inschrijvingen zijn bewaard.";
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
			lblSubscriptionsLeft.Text = course.openSubscriptions.ToString() + " plaatsen vrij";
			lblPrice.Text = "€ " + course.price;
		}

		private void refreshLists(int courseID) {
			crud crud = new crud();

			List<child> subscribedChildren = (List<child>) Session["subscribedChildren"] ?? crud.getAllSubscriptionsForCourse(courseID).Select(x => x.child).ToList<child>();
			List<child> childrenForUserProfile = new crud().getAllChildrenForUserProfile(Convert.ToInt32(Session["userID"]));

			subscribedChildren = subscribedChildren.Where(sChild => childrenForUserProfile.Find(uChild => uChild.id == sChild.id) != null ? true : sChild.id > int.MaxValue - 10001 ? true : false).ToList<child>();
			subscribedChildren.ForEach(sChild => childrenForUserProfile.Remove(childrenForUserProfile.Find(uChild => uChild.id == sChild.id)));

			Session["subscribedChildren"] = subscribedChildren;

			// fill select box (all children for user profile)
			if (childrenForUserProfile.Count < 1) {
				divExistingChildSelector.Visible = false;
				divHasNoExistingChildren.Visible = true;
			} else {
				divExistingChildSelector.Visible = true;
				divHasNoExistingChildren.Visible = false;
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

		private DateTime CreateDate(string value) {
			string[] split = value.Split('/');
			int day = Convert.ToInt32(split[0]);
			int month = Convert.ToInt32(split[1]);
			int year = Convert.ToInt32(split[2]);

			return new DateTime(year, month, day);
		}

		private bool childHasCorrectAge(DateTime birthDate, int ageFrom, int ageToInclusive) {
			DateTime yearFrom = DateTime.Now.AddYears(-ageFrom);
			DateTime yearTo = DateTime.Now.AddYears(-ageToInclusive);

			if ((yearTo < birthDate && birthDate < yearFrom) || (birthDate.Equals(yearTo))) {
				return true;
			}

			return false;
		}
	}
}