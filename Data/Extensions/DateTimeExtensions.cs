namespace snyder_volunteer_site.Data.Extensions
{
	public static class DateTimeExtensions
	{
		public static List<DateTime> GetDaysInMonth(this DateTime referenceDate)
			=> Enumerable.Range(1, DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month))
				.Select(day => new DateTime(referenceDate.Year, referenceDate.Month, day))
				.ToList();

		//public static IEnumerable<DateTime> GetAllDaysInView(this DateTime referenceDate)
		//	=> (new DateTime())


		public static int GetDaysNeeded(this DateTime referenceDate, bool isStart)
			=> referenceDate.DayOfWeek switch {
				DayOfWeek.Sunday => isStart ? 0 : 6,
				DayOfWeek.Monday => isStart ? 1 : 5,
				DayOfWeek.Tuesday => isStart ? 2 : 4,
				DayOfWeek.Wednesday => isStart ? 3 : 3,
				DayOfWeek.Thursday => isStart ? 4 : 2,
				DayOfWeek.Friday => isStart ? 5 : 1,
				_ => isStart ? 6 : 0,
			};
	}
}
