using System;
using System.Collections.Generic;
using System.Text;
using NinaSubscriptions.BO;
using NinaSubscriptions.Interfaces;
using NinaSubscriptions.DAL;
using System.Data;

namespace NinaSubscriptions.BLL {
	public class crud : IBLL {
		// DAL class
		private  IDAL dal = new DAL.crud();

		// IBLL implementation
		public int insertCourse(course course) {
			return Convert.ToInt32(getFirstRow(dal.insertCourse(course.courseType.id, course.startDate, course.endDateInclusive, course.startHour,
							 course.endHour, course.location.id, course.maxSubscriptions, course.price, course.description,
							 course.name))["id"]);
		}

		public course selectCourse(int id) {
			DataTable courseTable = dal.selectCourse(id);
			DataRow r = getFirstRow(courseTable);

			return getCourseFromDataRow(r);
		}

		public int updateCourse(course course) {
			return Convert.ToInt32(getFirstRow(dal.updateCourse(course.id, course.courseType.id, course.startDate, course.endDateInclusive,
													course.startHour, course.endHour, course.location.id, course.maxSubscriptions,
													course.price, course.description, course.name))["id"]);
		}

		public int deleteCourse(int id) {
			return Convert.ToInt32(getFirstRow(dal.deleteCourse(id))["id"]);
		}

		public List<course> getAllCourses() {
			DataTable table = dal.selectAllCourses();
			List<course> retlist = new List<course>();

			if (Convert.ToInt32(table.Rows[0]["id"]) != -1) {
				foreach (DataRow row in table.Rows) {
					retlist.Add(getCourseFromDataRow(row));
				}
			};

			return retlist;
		}

		public int insertSubscription(subscription subscription) {
				return Convert.ToInt32(getFirstRow(dal.insertSubscription(subscription.course.id, subscription.child.id,
																			   subscription.paymentConfirmed))["id"]);
		}

		public subscription selectSubscription(int id) {
			return getSubscriptionFromDatarow(getFirstRow(dal.selectSubscription(id)));
		}

		public int updateSubscription(subscription subscription) {
			return Convert.ToInt32(getFirstRow(dal.updateSubscription(subscription.id, subscription.course.id,
																	  subscription.child.id, subscription.paymentConfirmed))["id"]);
		}

		public int deleteSubscription(int id) {
			return Convert.ToInt32(getFirstRow(dal.deleteSubscription(id))["id"]);
		}

		public List<subscription> getSubscriptionOnCourseAndChild(int courseID, int childID) {
			DataTable table = dal.getSubscriptionOnCourseAndChild(courseID, childID);
			List<subscription> retlist = new List<subscription>();

			if (Convert.ToInt32(table.Rows[0]["id"]) != -1) {
				foreach (DataRow row in table.Rows) {
					retlist.Add(getSubscriptionFromDatarow(row));
				}
			}

			return retlist;
		}

		public List<subscription> getAllSubscriptionsForUserProfile(int userProfileID) {
			DataTable table = dal.getAllSubscriptionsForUserProfile(userProfileID);
			List<subscription> retlist = new List<subscription>();

			if (Convert.ToInt32(table.Rows[0]["id"]) != -1) {
				foreach (DataRow row in table.Rows) {
					retlist.Add(getSubscriptionFromDatarow(row));
				}
			}

			return retlist;
		}

		public List<subscription> getAllSubscriptionsForCourse(int courseID) {
			DataTable table = dal.getAllSubscriptionsForCourse(courseID);
			List<subscription> retlist = new List<subscription>();

			if (Convert.ToInt32(table.Rows[0]["id"]) != -1) {
				foreach (DataRow row in table.Rows) {
					retlist.Add(getSubscriptionFromDatarow(row));
				}
			}

			return retlist;
		}

		public List<subscription> getAllSubscriptionsForCoursesOnDate(DateTime courseDate) {
			DataTable table = dal.getAllSubscriptionsForCoursesOnDate(courseDate);
			List<subscription> retlist = new List<subscription>();

			if (Convert.ToInt32(table.Rows[0]["id"]) != -1) {
				foreach (DataRow row in table.Rows) {
					retlist.Add(getSubscriptionFromDatarow(row));
				}
			}

			return retlist;
		}

		public int insertUserProfile(userProfile profile) {
			return Convert.ToInt32(getFirstRow(dal.insertUserProfile(profile.name, profile.firstName, profile.street, profile.number,
																	 profile.postalCode, profile.place, profile.phone, profile.emailAddress,
																	 profile.userName, profile.passwordHash, profile.isAdmin))["id"]);
		}

		public userProfile selectUserProfile(int id) {
			return getProfileFromDatarow(getFirstRow(dal.selectUserProfile(id)));
		}

		public int updateUserProfile(userProfile profile) {
			return Convert.ToInt32(getFirstRow(dal.updateUserProfile(profile.id, profile.name, profile.firstName, profile.street, profile.number,
																	 profile.postalCode, profile.place, profile.phone, profile.emailAddress,
																	 profile.userName, profile.passwordHash, profile.isAdmin))["id"]);
		}

		public int deleteUserProfile(int id) {
			return Convert.ToInt32(getFirstRow(dal.deleteUserProfile(id))["id"]);
		}

		public List<userProfile> getAllUserProfiles() {
			DataTable table = dal.getAllUserProfiles();
			List<userProfile> retlist = new List<userProfile>();

			foreach (DataRow row in table.Rows) {
				retlist.Add(getProfileFromDatarow(row));
			}

			return retlist;
		}

		public int insertChild(child child) {
			return Convert.ToInt32(getFirstRow(dal.insertChild(child.name, child.firstName,
															   child.dateOfBirth, child.userProfileID))["id"]);
		}

		public child selectChild(int id) {
			return getChildFromDatarow(getFirstRow(dal.selectChild(id)));
		}

		public int updateChild(child child) {
			return Convert.ToInt32(getFirstRow(dal.updateChild(child.id, child.name, 
															   child.firstName, child.dateOfBirth,
															   child.userProfileID))["id"]);
		}

		public int deleteChild(int id) {
			return Convert.ToInt32(getFirstRow(dal.deleteChild(id))["id"]);
		}

		public List<child> getAllChildrenForUserProfile(int userProfileID) {
			DataTable table = dal.getAllChildrenForUserProfile(userProfileID);
			List<child> retlist = new List<child>();

			DataRow firstRow = getFirstRow(table);

			if (Convert.ToInt32(firstRow["id"]) != -1) {
				foreach (DataRow row in table.Rows) {
					retlist.Add(selectChild((int) row["id"]));
				}
			};

			return retlist;
		}

		public courseType selectCourseType(int id) {
			return getCourseTypeFromDatarow(getFirstRow(dal.selectCourseType(id)));
		}

		public List<courseType> getAllCourseTypes() {
			DataTable table = dal.getAllCourseTypes();
			List<courseType> retlist = new List<courseType>();

			foreach (DataRow row in table.Rows) {
				retlist.Add(getCourseTypeFromDatarow(row));
			}

			return retlist;
		}

		public location selectLocation(int id) {
			return getLocationFromDatarow(getFirstRow(dal.selectLocation(id)));
		}

		public List<location> getAllLocations() {
			DataTable table = dal.getAllLocations();
			List<location> retlist = new List<location>();

			foreach (DataRow row in table.Rows) {
				retlist.Add(getLocationFromDatarow(row));
			}

			return retlist;
		}

		public int getIdForCredentials(string username, string passwordHash) {
			return Convert.ToInt32(getFirstRow(dal.getIdForCredentials(username, passwordHash))["id"]);
		}


		// PRIVATE HELPERS	
		private DataRow getFirstRow(DataTable table) {
			if (table.Rows.Count < 1) { throw new requestedDataNotFoundException(); };
			return table.Rows[0];
		}

		private course getCourseFromDataRow(DataRow row) {
			course course = new course();

			course.courseType = selectCourseType(Convert.ToInt32(row["cursustypeID"]));
			course.description = row["omschrijving"].ToString();
			course.id = Convert.ToInt32(row["id"]);
			course.name = row["naam"].ToString();
			course.endDateInclusive = Convert.ToDateTime(row["datum_tot"]);
			course.endHour = row["einduur"].ToString();
			course.location = selectLocation(Convert.ToInt32(row["locatieID"]));
			course.maxSubscriptions = Convert.ToInt32(row["max_deelnemers"]);
			course.openSubscriptions = Convert.ToInt32(row["openAantalDeelnemers"]);
			course.price = Convert.ToInt32(row["kostprijs"]);
			course.startDate = Convert.ToDateTime(row["datum_van"]);
			course.startHour = row["startuur"].ToString();

			return course;
		}

		private subscription getSubscriptionFromDatarow(DataRow row) {
			subscription subscription = new subscription();

			if (Convert.ToInt32(row["id"].ToString()) != -1) {
				subscription.id = Convert.ToInt32(row["id"]);
				subscription.course = selectCourse(Convert.ToInt32(row["cursusID"]));
				subscription.child = selectChild(Convert.ToInt32(row["kindID"]));
				subscription.paymentConfirmed = Convert.ToBoolean(row["heeftBetaald"]);
			}

			return subscription;
		}

		private userProfile getProfileFromDatarow(DataRow row) {
			userProfile profile = new userProfile();

			profile.id = Convert.ToInt32(row["id"]);
			profile.children = getAllChildrenForUserProfile(profile.id);
			profile.emailAddress = row["emailadres"].ToString();
			profile.firstName = row["voornaam"].ToString();
			profile.isAdmin = Convert.ToBoolean(row["isAdmin"]);
			profile.name = row["naam"].ToString();
			profile.number = Convert.ToInt32(row["nummer"].ToString());
			profile.passwordHash = row["paswoord"].ToString();
			profile.phone = row["telefoonnummer"].ToString();
			profile.place = row["plaats"].ToString();
			profile.postalCode = Convert.ToInt32(row["postcode"]);
			profile.street = row["straat"].ToString();
			profile.userName = row["login"].ToString();

			return profile;
		}

		private child getChildFromDatarow(DataRow row) {
			child child = new child();

			child.id = Convert.ToInt32(row["id"]);
			child.name = row["achternaam"].ToString();
			child.firstName = row["voornaam"].ToString();
			child.dateOfBirth = Convert.ToDateTime(row["geboortedatum"]);
			child.userProfileID = Convert.ToInt32(row["profielID"]);

			return child;
		}

		private courseType getCourseTypeFromDatarow(DataRow row) {
			courseType ctype = new courseType();

			ctype.id = Convert.ToInt32(row["id"]);
			ctype.referrer = row["naam"].ToString();
			ctype.ageFrom = Convert.ToInt32(row["leeftijd_vanaf"]);
			ctype.ageToInclusive = Convert.ToInt32(row["leeftijd_tot_en_met"]);

			return ctype;
		}

		private location getLocationFromDatarow(DataRow row) {
			location location = new location();

			location.id = Convert.ToInt32(row["id"]);
			location.name = row["naam"].ToString();
			location.emailAddress = row["emailadres"].ToString();
			location.number = Convert.ToInt32(row["nummer"]);
			location.phone = row["telefoonnummer"].ToString();
			location.photoLink = row["foto_link"].ToString();
			location.street = row["straat"].ToString();
			location.place = row["plaats"].ToString();
			location.postalCode = row["postcode"].ToString();

			return location;
		}

	}
}
