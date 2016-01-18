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
		private IDAL dal = new DAL.crud();

		// IBLL implementation
		public int insertCourse(course course) {
			return Convert.ToInt32(getFirstRow(dal.insertCourse(course.courseType.id, course.startDate, course.endDateInclusive, course.startHour,
							 course.endHour, course.location.id, course.maxSubscriptions, course.price, course.description,
							 course.name))["id"]);
		}

		public course getCourse(int id) {
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

			foreach (DataRow row in table.Rows) {
				retlist.Add(getCourseFromDataRow(row));
			}

			return retlist;
		}

		public List<int> insertSubscription(subscription subscription) {
			List<int> retList = new List<int>();

			foreach (child child in subscription.children) {
				retList.Add(Convert.ToInt32(getFirstRow(dal.insertSubscription(subscription.course.id, child.id, subscription.paymentConfirmed))["id"]));
			}

			return retList;
		}

		public subscription selectSubscription(int id) {
			return getSubscriptionFromDatarow(getFirstRow(dal.selectSubscription(id)));
		}

		public int updateSubscription(subscription subscription) {
			throw new NotImplementedException();
		}

		public int deleteSubscription(int id) {
			throw new NotImplementedException();
		}

		public List<subscription> getAllSubscriptionsForUserProfile(int userProfileID) {
			throw new NotImplementedException();
		}

		public List<subscription> getAllSubscriptionsForCourse(int courseID) {
			throw new NotImplementedException();
		}

		public int insertUserProfile(userProfile profile) {
			throw new NotImplementedException();
		}

		public userProfile selectUserProfile(int id) {
			throw new NotImplementedException();
		}

		public int updateUserProfile(userProfile profile) {
			throw new NotImplementedException();
		}

		public int deleteUserProfile(int id) {
			throw new NotImplementedException();
		}

		public int insertChild(child child) {
			throw new NotImplementedException();
		}

		public child selectChild(int id) {
			throw new NotImplementedException();
		}

		public int updateChild(child child) {
			throw new NotImplementedException();
		}

		public int deleteChild(int id) {
			throw new NotImplementedException();
		}

		public List<child> getAllChildrenForUserProfile(int userProfileID) {
			throw new NotImplementedException();
		}

		public courseType selectCourseType(int id) {
			throw new NotImplementedException();
		}

		public location selectLocation(int id) {
			throw new NotImplementedException();
		}

		// PRIVATE HELPERS	
		private DataRow getFirstRow(DataTable table) {
			if (table.Rows.Count < 1) { throw new courseNotFoundException(); };
			return table.Rows[0];
		}

		private course getCourseFromDataRow(DataRow row) {
			course course = new course();

			course.courseType = selectCourseType(Convert.ToInt32(row["cursustypeID"]));
			course.description = row["omschrijving"].ToString();
			course.id = Convert.ToInt32(row["id"]);
			course.name = row["naam"].ToString();
			course.endDateInclusive = Convert.ToDateTime(row["datum_tot"]);
			course.endHour = Convert.ToInt32(row["einduur"]);
			course.location = selectLocation(Convert.ToInt32(row["locatieID"]));
			course.maxSubscriptions = Convert.ToInt32(row["max_deelnemers"]);
			course.price = Convert.ToInt32(row["kostprijs"]);
			course.startDate = Convert.ToDateTime(row["datum_van"]);
			course.startHour = Convert.ToInt32(row["startuur"]);

			return course;
		}

		private subscription getSubscriptionFromDatarow(DataRow row) {
			subscription subscription = new subscription();

			subscription.id = Convert.ToInt32(row["id"]);
			subscription.course = getCourse(Convert.ToInt32(row["cursusID"]));
			subscription.children = getAllChildrenForUserProfile(Convert.ToInt32(row["profielID"]));
			subscription.paymentConfirmed = Convert.ToBoolean(row["heeftBetaald"]);

			return subscription;
		}
	}
}
