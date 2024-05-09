using Microsoft.Data.SqlClient;

namespace snyder_volunteer_site.Data.DataBase
{
	public class DBConnection
	{
		public static string ConnectionString => GetConnectionString();
		public static SqlConnection Connection => new SqlConnection(GetConnectionString());
		private static string GetConnectionString()
		{
			//"BROXTON-LAPTOP";

			var connStringBuilder = new SqlConnectionStringBuilder()
			{
				DataSource = "BROXTON-LAPTOP",
				InitialCatalog = "SnyderProjectDB",
				IntegratedSecurity = true,
				TrustServerCertificate = true,
			};

			return connStringBuilder.ConnectionString;
		}
	}
}
