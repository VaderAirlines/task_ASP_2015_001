using NinaSubscriptions.BLL;
using NinaSubscriptions.BO;
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
		public bool saveChangesToCourse(string courseID, string description, string courseTypeID,
										string startDate, string endDate, string locationID,
										string maxSubscriptions, string price) {

			crud crud = new crud();
			course course = crud.selectCourse(Convert.ToInt32(courseID));

			course.description = description;
			course.courseType = crud.selectCourseType(Convert.ToInt32(courseTypeID));
			course.startDate = Convert.ToDateTime(startDate);
			course.endDateInclusive = Convert.ToDateTime(endDate);
			course.location = crud.selectLocation(Convert.ToInt32(locationID));
			course.maxSubscriptions = Convert.ToInt32(maxSubscriptions);
			course.price = Convert.ToInt32(price);

			if (crud.updateCourse(course) > 0) { return true; };

			return false;
		}
	}
}
