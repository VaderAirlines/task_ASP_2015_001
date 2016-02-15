using System;
using System.Collections.Generic;
using System.Text;
using NinaSubscriptions.BO;

namespace NinaSubscriptions.Interfaces {
	public interface IBLL {

		// COURSES		
		int insertCourse(course course);
		course selectCourse(int id);
		int updateCourse(course course);
		int deleteCourse(int id);
		List<course> getAllCourses();

		// SUBSCRIPTIONS
		int insertSubscription(subscription subscription);
		subscription selectSubscription(int id);
		int updateSubscription(subscription subscription);
		int deleteSubscription(int id);
		List<subscription> getAllSubscriptionsForUserProfile(int userProfileID);
		List<subscription> getAllSubscriptionsForCourse(int courseID);
		List<subscription> getAllSubscriptionsForCoursesOnDate(DateTime courseDate);
		
		// USERPROFILES
		int insertUserProfile(userProfile profile);
		userProfile selectUserProfile(int id);
		int updateUserProfile(userProfile profile);
		int deleteUserProfile(int id);
		List<userProfile> getAllUserProfiles();
		
		// CHILDREN
		int insertChild(child child);
		child selectChild(int id);
		int updateChild(child child);
		int deleteChild(int id);
		List<child> getAllChildrenForUserProfile(int userProfileID);

		// COURSE TYPES
		courseType selectCourseType(int id);
		List<courseType> getAllCourseTypes();

		// LOCATIONS
		location selectLocation(int id);
		List<location> getAllLocations();

		// HELPERS
		int getIdForCredentials(string username, string passwordHash);
	}
}
