using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NinaSubscriptions.Interfaces {
	public interface IDAL {

		// COURSES -------------------------------------------------------------------------------------
		DataTable insertCourse(int courseTypeID, DateTime startDate, DateTime endDateInclusive, 
						  string startHour, string endHour, int locationID, int maxSubscriptions, int price, 
						  string description, string name);

		DataTable selectCourse(int id);

		DataTable updateCourse(int id, int courseTypeID, DateTime startDate, DateTime endDateInclusive, 
						  string startHour, string endHour, int locationID, int maxSubscriptions, int price, 
						  string description, string name);

		DataTable deleteCourse(int id);

		DataTable selectAllCourses();


		// SUBSCRIPTIONS --------------------------------------------------------------------------------
		DataTable insertSubscription(int courseID, int childID, bool hasPayed);

		DataTable selectSubscription(int id);

		DataTable updateSubscription(int id, int courseID, int childID, bool hasPayed);

		DataTable deleteSubscription(int id);

		DataTable getSubscriptionOnCourseAndChild(int courseID, int childID);

		DataTable getAllSubscriptionsForUserProfile(int userProfileID);

		DataTable getAllSubscriptionsForCourse(int courseID);

		DataTable getAllSubscriptionsForCoursesOnDate(DateTime courseDate);


		// USERPROFILES ------------------------------------------------------------------------------
		DataTable insertUserProfile(string name, string firstName, string street, int number, int postalCode, 
								   string place, string phone, string emailAddress, string username, string passwordHash,
								   Boolean isAdmin);

		DataTable selectUserProfile(int id);

		DataTable updateUserProfile(int id, string name, string firstName, string street, int number, int postalCode, 
								   string place, string phone, string emailAddress, string username, string passwordHash,
								   Boolean isAdmin);

		DataTable deleteUserProfile(int id);

		DataTable getAllUserProfiles();


		// CHILDREN ---------------------------------------------------------------------------------
		DataTable insertChild(string name, string firstName, DateTime dateOfBirth, int userProfileID);

		DataTable selectChild(int id);

		DataTable updateChild(int id, string name, string firstName, DateTime dateOfBirth, int userProfileID);

		DataTable deleteChild(int id);

		DataTable getAllChildrenForUserProfile(int userProfileID);


		// COURSE TYPES
		DataTable selectCourseType(int id);
		DataTable getAllCourseTypes();


		// LOCATIONS
		DataTable selectLocation(int id);
		DataTable getAllLocations();

		// HELPERS
		DataTable getIdForCredentials(string username, string passwordHash);
	}
}
