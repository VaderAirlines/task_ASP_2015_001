using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NinaSubscriptions.Master_Pages;
using NinaSubscriptions.BO;
using NinaSubscriptions.BLL;

namespace NinaSubscriptions.Pages.Public {

	public partial class bekijkAanbod:System.Web.UI.Page {

		protected void Page_Load(object sender,EventArgs e) {
			NinaSubscriptionsMaster master = this.Master as NinaSubscriptionsMaster;

			// check if user is already logged in
			if(Session["userID"] != null) { master.setLoggedInUser(Convert.ToInt32(Session["userID"])); }

			// set page title
			master.setHeaderTitle("Bekijk aanbod");

			// tests
			crud crud = new crud();
			course test = crud.getCourse(1);

			if (1 == 1) return;

			//DataTable table = DAC.execute(spBase.course, spCommand.select, new Dictionary<string,string>() { {"id", "1"} });

			//course course = new course() {
			//	courseType = new courseType() { id = 1 },
			//	startDate = new DateTime(35000), 
			//	endDateInclusive = new DateTime(350000),
			//	startHour = 1500,
			//	endHour = 1800,
			//	location = new location() { id = 1 },
			//	maxSubscriptions = 15,
			//	description = "test van DAC",
			//	name = "test van dacia logan"
			//};

			//INinaSubscriptions crud = new DAL.crud();

			//DataTable table = crud.insertCourse(course.courseType.id, course.startDate, course.endDateInclusive, course.startHour,
			//									course.endHour, course.location.id, course.maxSubscriptions, course.price,
			//									course.description, course.name);

			//int newID = dataHelper.getIdFromDataTable(table);
		}
	}
}