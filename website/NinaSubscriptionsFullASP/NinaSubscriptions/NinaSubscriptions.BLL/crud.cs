using System;
using System.Collections.Generic;
using System.Text;
using NinaSubscriptions.BO;
using NinaSubscriptions.Interfaces;
using NinaSubscriptions.DAL;
using System.Data;

namespace NinaSubscriptions.BLL {
	public class crud:IBLL {
		// DAL class
		private IDAL dal = new DAL.crud();

		// IBLL implementation
		public int insertCourse(course course) {
			throw new NotImplementedException();
		}

		public course getCourse(int id) {
			DataTable courseTable = dal.selectCourse(id);
			DataRow r = getFirstRow(courseTable);

			course course = new course() {
				id = Convert.ToInt32(r["id"]),
				name = r["naam"].ToString(),
				description = r["omschrijving"].ToString(),
				courseType = new courseType() { id = 1, ageFrom = 4, ageToInclusive = 6, referrer = "kleuters" },//this.selectCourseType(Convert.ToInt32(r["cursusTypeID"])),
				startDate = Convert.ToDateTime(r["datum_van"]),
				endDateInclusive = Convert.ToDateTime(r["datum_tot"]),
				startHour = Convert.ToInt32(r["startuur"]),
				endHour = Convert.ToInt32(r["einduur"]),
				location = new location() { id = 1, name = "locatie van joske" }, //this.selectLocation(Convert.ToInt32(r["locatieID"])),
				maxSubscriptions = Convert.ToInt32(r["max_deelnemers"]),
				price = Convert.ToInt32(r["kostprijs"])
			};

			return course;
		}

		public int updateCourse(course course) {
			throw new NotImplementedException();
		}

		public int deleteCourse(int id) {
			throw new NotImplementedException();
		}

		public List<course> getAllCourses() {
			throw new NotImplementedException();
		}

		public int insertSubscription(subscription subscription) {
			throw new NotImplementedException();
		}

		public subscription selectSubscription(int id) {
			throw new NotImplementedException();
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
			if(table.Rows.Count < 1) { throw new courseNotFoundException(); };
			return table.Rows[0];
		}

	}
}
