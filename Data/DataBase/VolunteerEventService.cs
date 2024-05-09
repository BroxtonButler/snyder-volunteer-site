using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace snyder_volunteer_site.Data.DataBase
{
	public static class VolunteerEventService
	{
		public async static Task<List<VolunteerEvent>> GetVolunteerEvents(DateTime selectedDate)
		{
			var con = new SqlConnection(DBConnection.ConnectionString);

			string query = $"Select * from VolunteerEvent where month(eventDate) = {selectedDate.Month} and year(eventDate) = {selectedDate.Year}";

			SqlCommand cmd = new(query, con);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			
			var volunteerEvents = new List<VolunteerEvent>();
			while (dr.Read())
			{
				var eventId = (Guid)dr["eventId"];
				var eventName = (string)dr["eventName"];
				var eventDescription = (string)dr["eventDescription"];
				var eventDate = (DateTime)dr["eventDate"];

				volunteerEvents.Add(new VolunteerEvent(eventId, eventName, eventDescription, eventDate)) ;
			}
			con.Close();

			return volunteerEvents;
		}

		public static void AddVolunteerEvent(DateTime eventDate, string eventName, string eventDescription)
		{
			var eventId = Guid.NewGuid();
			var con = new SqlConnection(DBConnection.ConnectionString);
			
			con.Open();
			using (SqlTransaction trans = con.BeginTransaction())
			{
				using (SqlCommand cmd = con.CreateCommand())
				{
					cmd.Transaction = trans;
					cmd.CommandText = @"insert into VolunteerEvent (eventId, eventDate, eventName, eventDescription) values (@eventId, @eventDate, @eventName, @eventDescription);";
					cmd.Parameters.AddWithValue("@eventId", eventId);
					cmd.Parameters.AddWithValue("@eventDate", eventDate.Date.ToString("yyyy-MM-dd"));
					cmd.Parameters.AddWithValue("@eventName", eventName);
					cmd.Parameters.AddWithValue("@eventDescription", eventDescription);
					cmd.ExecuteNonQuery();
					trans.Commit();
				}
			}
			con.Close();
		}
	}
}
