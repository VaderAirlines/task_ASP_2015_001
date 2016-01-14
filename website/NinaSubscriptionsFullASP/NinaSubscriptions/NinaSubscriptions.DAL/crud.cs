using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NinaSubscriptions.Interfaces;

namespace NinaSubscriptions.DAL {
	public class crud:IDAL {

		string sqlDateFormat = "yyyy-MM-dd HH:MM:ss";

		public DataTable insertCourse(int courseTypeID,DateTime startDate,DateTime endDateInclusive,int startHour,int endHour,
									  int locationID,int maxSubscriptions,int price,string description,string name) {

			Dictionary<string,string> parameters = new Dictionary<string,string>() {
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

			return DAC.execute(spBase.course,spCommand.insert,parameters);
		}

		public DataTable selectCourse(int id) {
			return DAC.execute(spBase.course, spCommand.select, new Dictionary<string,string>() { {"id", id.ToString() } });
		}

		public DataTable updateCourse(int id,int courseTypeID,DateTime startDate,DateTime endDateInclusive,int startHour,int endHour,int locationID,int maxSubscriptions,int price,string description,string name) {
			throw new NotImplementedException();
		}

		public DataTable deleteCourse(int id) {
			throw new NotImplementedException();
		}

		public DataTable selectAllCourses() {
			throw new NotImplementedException();
		}

		public DataTable insertSubscription(int courseID,int childID,bool hasPayed) {
			throw new NotImplementedException();
		}

		public DataTable selectSubscription(int id) {
			throw new NotImplementedException();
		}

		public DataTable updateSubscription(int id,int courseID,int childID,bool hasPayed) {
			throw new NotImplementedException();
		}

		public DataTable deleteSubscription(int id) {
			throw new NotImplementedException();
		}

		public DataTable getAllSubscriptionsForUserProfile(int userProfileID) {
			throw new NotImplementedException();
		}

		public DataTable insertUserProfile(string name,string firstName,string street,int number,int postalCode,string place,string phone,string emailAddress,string username,string passwordHash) {
			throw new NotImplementedException();
		}

		public DataTable selectUserProfile(int id) {
			throw new NotImplementedException();
		}

		public DataTable updateUserProfile(int id,string name,string firstName,string street,int number,int postalCode,string place,string phone,string emailAddress,string username,string passwordHash) {
			throw new NotImplementedException();
		}

		public DataTable deleteUserProfile(int id) {
			throw new NotImplementedException();
		}

		public DataTable insertChild(string name,string firstName,DateTime dateOfBirth,int userProfileID) {
			throw new NotImplementedException();
		}

		public DataTable selectChild(int id) {
			throw new NotImplementedException();
		}

		public DataTable updateChild(int id,string name,string firstName,DateTime dateOfBirth,int userProfileID) {
			throw new NotImplementedException();
		}

		public DataTable deleteChild(int id) {
			throw new NotImplementedException();
		}

		public DataTable getAllChildrenForUserProfile(int userProfileID) {
			throw new NotImplementedException();
		}
		
		public DataTable getAllSubscriptionsForCourse(int courseID) {
			throw new NotImplementedException();
		}


		public DataTable selectCourseType(int id) {
			throw new NotImplementedException();
		}

		public DataTable selectLocation(int id) {
			throw new NotImplementedException();
		}
	}
}
