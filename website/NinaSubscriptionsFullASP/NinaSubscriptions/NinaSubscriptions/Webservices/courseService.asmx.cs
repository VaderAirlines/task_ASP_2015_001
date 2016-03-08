using NinaSubscriptions.BLL;
using NinaSubscriptions.BO;
using NinaSubscriptions.Custom_validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NinaSubscriptions.Webservices {
	/// <summary>
	/// Summary description for courseService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class courseService : System.Web.Services.WebService {

		[WebMethod]
		public string saveChangesToCourse(string courseID, string description, string courseTypeID,
										string startDate, string endDate, string locationID,
										string maxSubscriptions, string price, string startHour,
										string endHour, string name) {

			const string success = "success";
			const string failed = "failed";

			// validate fields before continuing
			if (string.IsNullOrWhiteSpace(courseID) ||
				string.IsNullOrWhiteSpace(description) ||
				string.IsNullOrWhiteSpace(courseTypeID) ||
				string.IsNullOrWhiteSpace(startDate) ||
				string.IsNullOrWhiteSpace(endDate) ||
				string.IsNullOrWhiteSpace(locationID) ||
				string.IsNullOrWhiteSpace(maxSubscriptions) ||
				string.IsNullOrWhiteSpace(price) ||
				string.IsNullOrWhiteSpace(startHour) ||
				string.IsNullOrWhiteSpace(endHour) ||
				string.IsNullOrWhiteSpace(name)) {
					return "Gelieve alle velden in te vullen";
			}

			customValidator validator = new customValidator();
			if (!validator.validDate(startDate) || !validator.validDate(endDate))
				return "Gelieve geldige datums in te vullen (dd/mm/yyyy)";

			if (!validator.hour(startHour) || !validator.hour(endHour))
				return "Gelieve geldige uren in te vullen (hh:mm)";


			// if all is validated, continue...
			crud crud = new crud();
			course course = crud.selectCourse(Convert.ToInt32(courseID));

			course.name = name;
			course.description = description;
			course.courseType = crud.selectCourseType(Convert.ToInt32(courseTypeID));
			course.startDate = Convert.ToDateTime(startDate);
			course.endDateInclusive = Convert.ToDateTime(endDate);
			course.location = crud.selectLocation(Convert.ToInt32(locationID));
			course.maxSubscriptions = Convert.ToInt32(maxSubscriptions);
			course.price = Convert.ToInt32(price);
			course.startHour = startHour;
			course.endHour = endHour;

			if (crud.updateCourse(course) > 0) { return success; };

			return failed;
		}
	}
}
