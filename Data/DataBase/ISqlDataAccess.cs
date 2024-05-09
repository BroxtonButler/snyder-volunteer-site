namespace snyder_volunteer_site.Data.DataBase
{
	public interface ISqlDataAccess
	{
		Task<List<T>> LoadData<T>(string storedProc, string connectionName, object? parameters);

		//this is the interface
		Task SaveData(string storedProc, string connectionName, object parameters);
	}
}
