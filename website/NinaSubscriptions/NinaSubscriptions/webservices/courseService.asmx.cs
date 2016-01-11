using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace NinaSubscriptions.webservices {

	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	[ScriptService]
	public class courseService:System.Web.Services.WebService {

		[WebMethod]
		public course getCourse(string id) {
			course course = null;

			using(SqlConnection con = connectionManager.getConnection()) {
				using(SqlCommand com = new SqlCommand("getCourse",con)) {
					com.CommandType = System.Data.CommandType.StoredProcedure;
					com.Parameters.AddWithValue("id",Convert.ToInt32(id));

					try {
						con.Open();

						SqlDataReader reader = com.ExecuteReader();

						if(reader.HasRows) {
							course = new course();

							while(reader.Read()) {

								course.id = Convert.ToInt32(reader["id"]);
								course.datumVan = Convert.ToDateTime(reader["datum_van"]).ToShortDateString();
								course.datumTot = Convert.ToDateTime(reader["datum_tot"]).ToShortDateString();
								course.startuur = Convert.ToInt32(reader["startuur"]);
								course.einduur = Convert.ToInt32(reader["einduur"]);
								course.maxDeelnemers = Convert.ToInt32(reader["max_deelnemers"]);
								course.kostprijs = Convert.ToInt32(reader["kostprijs"]);
								course.naam = reader["cursusNaam"].ToString();
								course.omschrijving = reader["omschrijving"].ToString();
								course.leeftijdVanaf = Convert.ToInt32(reader["leeftijd_vanaf"]);
								course.leeftijdTotEnMet = Convert.ToInt32(reader["leeftijd_tot_en_met"]);
								course.fotoLink = reader["foto_link"].ToString();
								course.locatieNaam = reader["locatieNaam"].ToString();
								course.locatieAdres = reader["locatieAdres"].ToString();
							};
						};

					} catch(Exception ex) {
						return new course() { naam = "error", locatieNaam = ex.Message };
					};

				}
			}
			
			return course;
		}

		
		[WebMethod]
		public List<course> getAllCourses() {
			List<course> courses = null;

			using(SqlConnection con = connectionManager.getConnection()) {
				using(SqlCommand com = new SqlCommand("getAllCourses",con)) {
					com.CommandType = System.Data.CommandType.StoredProcedure;

					try {
						con.Open();

						SqlDataReader reader = com.ExecuteReader();

						if(reader.HasRows) {
							courses = new List<course>();

							while(reader.Read()) {
								course course = new course();

								course.id = Convert.ToInt32(reader["id"]);
								course.datumVan = Convert.ToDateTime(reader["datum_van"]).ToShortDateString();
								course.datumTot = Convert.ToDateTime(reader["datum_tot"]).ToShortDateString();
								course.startuur = Convert.ToInt32(reader["startuur"]);
								course.einduur = Convert.ToInt32(reader["einduur"]);
								course.maxDeelnemers = Convert.ToInt32(reader["max_deelnemers"]);
								course.kostprijs = Convert.ToInt32(reader["kostprijs"]);
								course.naam = reader["cursusNaam"].ToString();
								course.omschrijving = reader["omschrijving"].ToString();
								course.leeftijdVanaf = Convert.ToInt32(reader["leeftijd_vanaf"]);
								course.leeftijdTotEnMet = Convert.ToInt32(reader["leeftijd_tot_en_met"]);
								course.fotoLink = reader["foto_link"].ToString();
								course.locatieNaam = reader["locatieNaam"].ToString();
								course.locatieAdres = reader["locatieAdres"].ToString();

								courses.Add(course);
							};
						};

					} catch(Exception ex) {
						return new List<course>() { new course() { naam = "error", locatieNaam = ex.Message } };
					};

				}
			}
			
			return courses;
		}
	}
}
