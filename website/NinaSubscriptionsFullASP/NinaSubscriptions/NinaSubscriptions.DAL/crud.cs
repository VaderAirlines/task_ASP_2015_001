using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NinaSubscriptions.Interfaces;

namespace NinaSubscriptions.DAL {
	public class crud : IDAL {

		string sqlDateFormat = "yyyy-MM-dd HH:MM:ss";

		public DataTable insertCourse(int courseTypeID, DateTime startDate, DateTime endDateInclusive, string startHour, string endHour,
									  int locationID, int maxSubscriptions, int price, string description, string name) {

			Dictionary<string, string> parameters = new Dictionary<string, string>() {
				{ "courseTypeID", courseTypeID.ToString() },
				{ "startDate", startDate.ToString(sqlDateFormat) },
				{ "endDateInclusive", endDateInclusive.ToString(sqlDateFormat) },
				{ "startHour", startHour.ToString() },
				{ "endHour", endHour.ToString() },
				{ "locationID", locationID.ToString() },
				{ "maxSubscriptions", maxSubscriptions.ToString() },
				{ "price", price.ToString() },
				{ "description", description },
				{ "name", name }
			};

			return DAC.execute(spBase.course, spCommand.insert, parameters);
		}

		public DataTable selectCourse(int id) {
			return DAC.execute(spBase.course, spCommand.select, new Dictionary<string, string>() { 
				{ "id", id.ToString() } 
			});
		}

		public DataTable updateCourse(int id, int courseTypeID, DateTime startDate, DateTime endDateInclusive, string startHour,
			string endHour, int locationID, int maxSubscriptions, int price, string description, string name) {

			Dictionary<string, string> parameters = new Dictionary<string, string>() {
				{ "id", id.ToString() },
				{ "courseTypeID", courseTypeID.ToString() },
				{ "startDate", startDate.ToString(sqlDateFormat) },
				{ "endDateInclusive", endDateInclusive.ToString(sqlDateFormat) },
				{ "startHour", startHour.ToString() },
				{ "endHour", endHour.ToString() },
				{ "locationID", locationID.ToString() },
				{ "maxSubscriptions", maxSubscriptions.ToString() },
				{ "price", price.ToString() },
				{ "description", description },
				{ "name", name }
			};

			return DAC.execute(spBase.course, spCommand.update, parameters);
		}

		public DataTable deleteCourse(int id) {
			return DAC.execute(spBase.course, spCommand.delete, new Dictionary<string, string>() { 
				{ "id", id.ToString() } 
			});
		}

		public DataTable selectAllCourses() {
			return DAC.execute(spBase.course, spCommand.selectAll);
		}

		public DataTable insertSubscription(int courseID, int childID, bool hasPayed) {
			Dictionary<string, string> parameters = new Dictionary<string, string>() {
				{ "courseID", courseID.ToString() },
				{ "childID", childID.ToString() },
				{ "hasPayed", hasPayed.ToString() }
			};

			return DAC.execute(spBase.subscription, spCommand.insert, parameters);
		}

		public DataTable selectSubscription(int id) {
			return DAC.execute(spBase.subscription, spCommand.select, new Dictionary<string, string>() { 
				{ "id", id.ToString() } 
			});
		}

		public DataTable updateSubscription(int id, int courseID, int childID, bool hasPayed) {
			Dictionary<string, string> parameters = new Dictionary<string, string>() {
				{ "id", id.ToString() },
				{ "courseID", courseID.ToString() },
				{ "childID", childID.ToString() },
				{ "hasPayed", hasPayed.ToString() }
			};

			return DAC.execute(spBase.subscription, spCommand.update, parameters);
		}

		public DataTable deleteSubscription(int id) {
			return DAC.execute(spBase.subscription, spCommand.delete, new Dictionary<string, string>() { 
				{ "id", id.ToString() } 
			});
		}

		public DataTable getSubscriptionOnCourseAndChild(int courseID, int childID) {
			return DAC.execute(spBase.subscription, spCommand.selectAllForCourseAndChild, new Dictionary<string, string>() { 
				 { "courseID", courseID.ToString() },
				 {	"childID", childID.ToString() }
			});
		}

		public DataTable getAllSubscriptionsForUserProfile(int userProfileID) {
			return DAC.execute(spBase.subscription, spCommand.selectAllForUserProfile, new Dictionary<string, string>() { 
				{ "userProfileID", userProfileID.ToString() } 
			});
		}

		public DataTable insertUserProfile(string name, string firstName, string street, int number, int postalCode, 
											string place, string phone, string emailAddress, string username, 
											string passwordHash, Boolean isAdmin) {
			Dictionary<string, string> parameters = new Dictionary<string, string>() { 
				{ "name", name },
				{ "firstName", firstName },
				{ "street", street },
				{ "number", number.ToString() },
				{ "postalCode", postalCode.ToString() },
				{ "place", place },
				{ "phone", phone },
				{ "emailAddress", emailAddress },
				{ "userName", username },
				{ "passwordHash", passwordHash },
				{ "isAdmin", isAdmin.ToString() }
			};

			return DAC.execute(spBase.userProfile, spCommand.insert, parameters);
		}

		public DataTable selectUserProfile(int id) {
			return DAC.execute(spBase.userProfile, spCommand.select, new Dictionary<string, string>() { 
				{ "id", id.ToString() }
			});
		}

		public DataTable updateUserProfile(int id, string name, string firstName, string street, int number, int postalCode, 
										   string place, string phone, string emailAddress, string username, 
										   string passwordHash, Boolean isAdmin) {
			Dictionary<string, string> parameters = new Dictionary<string, string>() { 
				{ "id", id.ToString() },
				{ "name", name },
				{ "firstName", firstName },
				{ "street", street },
				{ "number", number.ToString() },
				{ "postalCode", postalCode.ToString() },
				{ "place", place },
				{ "phone", phone },
				{ "emailAddress", emailAddress },
				{ "userName", username },
				{ "passwordHash", passwordHash },
				{ "isAdmin", isAdmin.ToString() }
			};

			return DAC.execute(spBase.userProfile, spCommand.update, parameters);
		}

		public DataTable deleteUserProfile(int id) {
			return DAC.execute(spBase.userProfile, spCommand.delete, new Dictionary<string, string>() { 
				{ "id", id.ToString() }
			});
		}

		public DataTable getAllUserProfiles() {
			return DAC.execute(spBase.userProfile, spCommand.selectAll);
		}

		public DataTable insertChild(string name, string firstName, DateTime dateOfBirth, int userProfileID) {
			Dictionary<string, string> parameters = new Dictionary<string, string>() { 
				{ "name", name },
				{ "firstName", firstName },
				{ "dateOfBirth", dateOfBirth.ToString(sqlDateFormat) },
				{ "userProfileID", userProfileID.ToString() }
			};

			return DAC.execute(spBase.child, spCommand.insert, parameters);
		}

		public DataTable selectChild(int id) {
			return DAC.execute(spBase.child, spCommand.select, new Dictionary<string, string>() { 
				{ "id", id.ToString() }
			});
		}

		public DataTable updateChild(int id, string name, string firstName, DateTime dateOfBirth, int userProfileID) {
			Dictionary<string, string> parameters = new Dictionary<string, string>() {
				{ "id", id.ToString() },
				{ "name", name },
				{ "firstName", firstName },
				{ "dateOfBirth", dateOfBirth.ToString(sqlDateFormat) },
				{ "userProfileID", userProfileID.ToString() }
			};

			return DAC.execute(spBase.child, spCommand.update, parameters);
		}

		public DataTable deleteChild(int id) {
			return DAC.execute(spBase.child, spCommand.delete, new Dictionary<string, string>() { 
				{ "id", id.ToString() }
			});
		}

		public DataTable getAllChildrenForUserProfile(int userProfileID) {
			return DAC.execute(spBase.child, spCommand.selectAllForUserProfile, new Dictionary<string, string>() { 
				{ "userProfileID", userProfileID.ToString() }
			});
		}

		public DataTable getAllSubscriptionsForCourse(int courseID) {
			return DAC.execute(spBase.subscription, spCommand.selectAllForCourse, new Dictionary<string, string>() { 
				{ "courseID", courseID.ToString() }
			});
		}

		public DataTable getAllSubscriptionsForCoursesOnDate(DateTime courseDate) {
			return DAC.execute(spBase.subscription, spCommand.selectAllForCoursesOnDate, new Dictionary<string, string>() { 
				{ "courseDate", courseDate.Year + "/" + courseDate.Month + "/" + courseDate.Day }
			});
		}

		public DataTable selectCourseType(int id) {
			return DAC.execute(spBase.courseType, spCommand.select, new Dictionary<string, string>() { 
				{ "id", id.ToString() }
			});
		}

		public DataTable getAllCourseTypes() {
			return DAC.execute(spBase.courseType, spCommand.selectAll);
		}

		public DataTable selectLocation(int id) {
			return DAC.execute(spBase.location, spCommand.select, new Dictionary<string, string>() { 
				{ "id", id.ToString() }
			});
		}

		public DataTable getAllLocations() {
			return DAC.execute(spBase.location, spCommand.selectAll);
		}	
	
		public DataTable getIdForCredentials(string username, string passwordHash) {
			return DAC.execute(spBase.credentials, spCommand.check, new Dictionary<string, string>() { 
				{ "username", username },
				{ "password", passwordHash }
			});
		}

	}
}
