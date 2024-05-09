namespace snyder_volunteer_site.Data
{
	public class CalendarWeek
	{
		public CalendarWeek(IEnumerable<CalendarDay> days, int week)
		{
			Days = days.OrderBy( day => day.Date);
			Week = week;
		}

		public IEnumerable<CalendarDay> Days { get; }
		public int Week { get; }
	}
}
